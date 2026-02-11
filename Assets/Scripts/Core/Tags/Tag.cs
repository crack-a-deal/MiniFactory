using System;

public class Tag<T> : TagBase
{
    public event Action<T> ValueChanged;

    private T _value;
    public T Value
    {
        get
        {
            return _value;
        }
        set
        {
            if (Equals(value, _value))
            {
                return;
            }

            _value = value;
            ValueChanged?.Invoke(_value);
        }
    }

    public Tag(string id, T initialValue)
    {
        Id = id;
        _value = initialValue;
    }
}
