using UnityEngine;

namespace SwitchAttribute
{
    public class SwitchValueAttribute : PropertyAttribute
    {
        public readonly string key;
        public readonly object value;

        public SwitchValueAttribute(string key, object value)
        {
            this.key = key;
            this.value = value;
        }
    }
}