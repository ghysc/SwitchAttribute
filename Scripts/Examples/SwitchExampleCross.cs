using UnityEngine;

namespace SwitchAttribute
{
    [RequireComponent(typeof(SwitchExampleMain))]
    public class SwitchExampleCross : MonoBehaviour
    {
        [Header("Support for cross class defines")]
        [SwitchValue("My Key", SwitchEnum.EnumValue1)]
        public float ifEnumValue1 = 1f;

        [SwitchValue("My Key", SwitchEnum.EnumValue2)]
        public float ifEnumValue2 = 2f;

        [SwitchValue("My Key", SwitchEnum.EnumValue3)]
        public float ifEnumValue3 = 3f;
    }
}
