using System;
using UnityEngine;

namespace SwitchAttribute
{
    public enum PickerEnum
    {
        EnumValue1,
        EnumValue2,
        EnumValue3
    }

    public class SwitchExampleMain : MonoBehaviour
    {
        [Header("Support for Enum")]
        [SwitchKey("My Key")]
        public PickerEnum myEnum;

        [SwitchValue("My Key", PickerEnum.EnumValue1)]
        public float ifEnumValue1 = 1f;

        [SwitchValue("My Key", PickerEnum.EnumValue2)]
        public float ifEnumValue2 = 2f;

        [SwitchValue("My Key", PickerEnum.EnumValue3)]
        public float ifEnumValue3 = 3f;

        [Header("Support for boolean")]
        [SwitchKey("My Key 2")]
        public bool myBool;

        [SwitchValue("My Key 2", true)]
        public float ifBoolTrue = 1f;

        [SwitchValue("My Key 2", false)]
        public float ifBoolFalse = 0f;

        [Header("Support for Integer")]
        [SwitchKey("My Key 3")]
        [Range(0, 2)]
        public int myInt;

        [SwitchValue("My Key 3", 0)]
        public float ifInt0 = 0f;

        [SwitchValue("My Key 3", 1)]
        public float ifInt1 = 1f;

        [SwitchValue("My Key 3", 2)]
        public float ifInt2 = 2f;

        [Header("Support for float")]
        [SwitchKey("My Key 4")]
        [Range(0f, 2f)]
        public float myFloat;

        [SwitchValue("My Key 4", 0f)]
        public float ifFloat0 = 0f;

        [SwitchValue("My Key 4", 1f)]
        public float ifFloat1 = 1f;

        [SwitchValue("My Key 4", 2f)]
        public float ifFloat2 = 2f;

        [Header("Support for string")]
        [SwitchKey("My Key 5")]
        public string myString;

        [SwitchValue("My Key 5", "a")]
        public float ifStringA = 1f;

        [SwitchValue("My Key 5", "b")]
        public float ifStringB = 1f;

        [SwitchValue("My Key 5", "c")]
        public float ifStringC = 1f;

        [Header("Support for Scriptable Objects")]
        [SwitchKey("My Key 6")]
        public SwitchSOBase mySO;

        [SwitchValue("My Key 6", typeof(SwitchSO1))]
        public float ifSO1 = 1f;

        [SwitchValue("My Key 6", typeof(SwitchSO2))]
        public float ifSO2 = 2f;
    }
}