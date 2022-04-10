
**Switch Attribute README**
---

- Git : https://github.com/ghysc/SwitchAttribute

- Released with no license, do what you want with it.
 
- Developed under Unity 2021.2.8f1.

- You can safely remove the 'example' folders in 'scripts', and the two assets 'SwitchSO1' and 'SwitchSO2' that are used for examples.

- If you notice any issue, have any question, want to add a few features, feel free to contact me on twitter https://twitter.com/CyrilJGhys.
---

**How to use it?**
```c#
[SwitchKey("My Key")]
public bool myBool;

[SwitchValue("My Key", true)]
public float ifBoolTrue = 1f;

[SwitchValue("My Key", false)]
public float ifBoolFalse = 0f;
```

If `myBool` is true, only the field `ifBoolTrue` will show up in the inspector ; otherwise, only `ifBoolFalse` will.

Switch Attribute supports bool, enum, int, float, string and ScriptableObject.

For more examples on how to use them, please refer to ~/Scripts/Examples/SwitchExampleMain.cs
