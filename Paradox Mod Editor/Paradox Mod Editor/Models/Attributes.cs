using System;

[AttributeUsage(AttributeTargets.All)]
public class ScriptValueAttribute : Attribute
{
    private bool scriptValue;

    public ScriptValueAttribute(bool scriptValue)
    {
        this.scriptValue = scriptValue;
    }

    public virtual bool ScriptValue
    {
        get { return scriptValue; }
    }
}