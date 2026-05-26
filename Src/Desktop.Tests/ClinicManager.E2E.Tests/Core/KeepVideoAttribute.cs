using System;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false)]
public class KeepVideoAttribute : Attribute
{
    public bool Keep { get; }

    public KeepVideoAttribute(bool keep = true)
    {
        Keep = keep;
    }
}
