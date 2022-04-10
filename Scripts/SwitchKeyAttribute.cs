using UnityEngine;

namespace SwitchAttribute
{
    public class SwitchKeyAttribute : PropertyAttribute
    {
        public readonly string key;

        public SwitchKeyAttribute(string key)
        {
            this.key = key;
        } 
    }
}