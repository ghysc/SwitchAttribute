using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace SwitchAttribute
{
    [InitializeOnLoad]
    public class SwitchManager
    {
        // Store key + the field value
        private static Dictionary<string, object> defines = new Dictionary<string, object>();

        static SwitchManager()
        {
            defines.Clear();

            FindAllPickerAttributes();
        }

        private static void FindAllPickerAttributes()
        {
            MonoBehaviour[] monos = GameObject.FindObjectsOfType(typeof(MonoBehaviour)) as MonoBehaviour[];

            bool error = false;

            // First, manage all PickerDefines
            foreach (MonoBehaviour mono in monos)
            {
                FieldInfo[] objectFields = mono.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public);
                foreach (FieldInfo field in objectFields)
                {
                    SwitchKeyAttribute[] pickerDefines = Attribute.GetCustomAttributes(field, typeof(SwitchKeyAttribute)) as SwitchKeyAttribute[];

                    foreach (SwitchKeyAttribute pickerDefine in pickerDefines)
                    {
                        if (pickerDefine == null) continue;

                        // Throw an error if the key is already defined somewhere
                        if (defines.ContainsKey(pickerDefine.key))
                        {
                            Debug.LogError(field + " in " + mono + " defines a PickerDefine which already exists (redundant PickerDefine)");
                            error = true;
                        }
                        // Throw another error if there is a PickerDefine and a PickerResolve at the same time
                        else if (Attribute.GetCustomAttribute(field, typeof(SwitchValueAttribute)) != null)
                        {
                            Debug.LogError(field + " in " + mono + " shouldn't be a PickerDefine and a PickerResolve at the same time");
                            error = true;
                        }
                        // Otherwise register it
                        else
                        {
                            defines.Add(pickerDefine.key, field.GetValue(mono));
                        }
                    }
                }
            }

            // Check to avoid having multiple more errors in the inspector is there is already one
            if (error) return;

            // Then, manage all PickerResolves
            foreach (MonoBehaviour mono in monos)
            {
                FieldInfo[] objectFields = mono.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public);
                foreach (FieldInfo field in objectFields)
                {
                    SwitchValueAttribute[] pickerResolves = Attribute.GetCustomAttributes(field, typeof(SwitchValueAttribute)) as SwitchValueAttribute[];

                    foreach (SwitchValueAttribute pickerResolve in pickerResolves)
                    {
                        if (pickerResolve == null) continue;

                        // Throw an error if the PickerResolve.key isn't registered as a key
                        if (!defines.ContainsKey(pickerResolve.key))
                        {
                            Debug.LogError(field + "'s key (" + pickerResolve.key + ") in " + mono + " is not defined anywhere else");
                        }
                    }
                }
            }
        }

        public static bool ArePickerValuesIdentical(SwitchValueAttribute pickerResolve)
        {
            if (defines.TryGetValue(pickerResolve.key, out object obj))
            {
                // Check for similarities
                if (obj is bool || obj is int || obj is Enum || obj is string)
                {
                    if (Equals(pickerResolve.value, obj))
                        return true;
                }
                else if (obj is float)
                {
                    if (Mathf.Approximately(float.Parse("" + pickerResolve.value), float.Parse("" + obj)))
                        return true;
                }
                else if (obj is ScriptableObject so)
                {
                    if (so.GetType() == (Type)pickerResolve.value)
                        return true;
                }
            }

            return false;
        }

        public static void UpdateValue(string key, FieldInfo field, SerializedProperty property)
        {
            object obj = field.GetValue(property.serializedObject.targetObject);

            if (defines.ContainsKey(key))
                defines[key] = obj;
            // else case happens only when adding a component that already has a [PickerDefine] in it
            // -> there is no script recompilation
            // As such, the PickerManager isn't up to date
            else
                defines.Add(key, obj);
        }
    }
}