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
    [CustomPropertyDrawer(typeof(SwitchValueAttribute))] 
    public class SwitchValueDrawer : PropertyDrawer
    {
        private bool shown;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            // --- LOGIC ---
            // Get our SwitchValue
            SwitchValueAttribute pickerResolve =
                Attribute.GetCustomAttribute(fieldInfo, typeof(SwitchValueAttribute)) as SwitchValueAttribute;

            // And update our logic
            shown = SwitchManager.ArePickerValuesIdentical(pickerResolve);

            // --- VISUALS ---
            if (shown)
            {
                // Draw the default property
                EditorGUI.PropertyField(position, property, label, true);
            }
            else
            {
                // Do nothing, hide the property
            }
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            if (shown)
            {
                // Get the default property height
                return EditorGUI.GetPropertyHeight(property);
            }
            else
            {
                // Set it to 0
                return 0f;
            }
        }
    }
}