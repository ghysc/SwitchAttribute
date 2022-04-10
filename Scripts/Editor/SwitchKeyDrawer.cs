using System;
using UnityEditor;
using UnityEngine;

namespace SwitchAttribute
{
    /// <summary>
    /// We have to put some logic here
    /// Because it's the only place where we have a callback 
    /// for when the value changes in the inspector
    /// </summary>
    [CustomPropertyDrawer(typeof(SwitchKeyAttribute))]
    public class SwitchKeyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            // --- LOGIC ---
            // Get our SwitchKey
            SwitchKeyAttribute pickerDefine =
                Attribute.GetCustomAttribute(fieldInfo, typeof(SwitchKeyAttribute)) as SwitchKeyAttribute;

            // And update our SwitchManager's logic
            SwitchManager.UpdateValue(pickerDefine.key, fieldInfo, property);

            // --- VISUALS ---
            EditorGUI.PropertyField(position, property, label, true);
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUI.GetPropertyHeight(property);
        }
    }
}
