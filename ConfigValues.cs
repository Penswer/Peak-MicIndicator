
internal class ConfigValue<T>
{
    public bool constantUpdating;
    public T value;

    public ConfigValue(T value, bool constantUpdating = false)
    {
        this.value = value;
        this.constantUpdating = constantUpdating;
    }
}

internal class ConfigValues
{
}