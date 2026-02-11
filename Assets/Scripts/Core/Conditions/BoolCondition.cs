using UnityEngine;

public class BoolCondition : ICondition
{
    private readonly string _id;
    private readonly bool _expected;
    private readonly Tag<bool> _tag;

    public string Id => _id;

    private ConditionState _state = ConditionState.Inactive;

    public ConditionState State
    {
        get => _state;
        set
        {
            if (_state != value)
            {
                _state = value;
            }
        }
    }

    public BoolCondition(string id, Tag<bool> tag, bool expected)
    {
        _id = id;
        _tag = tag;
        _expected = expected;
    }

    public void Activate()
    {
        State = ConditionState.Pending;
        Debug.Log($"{_id}: [{State}]");
    }

    public void Deactivate()
    {
        State = ConditionState.Inactive;
        Debug.Log($"{_id}: [{State}]");
    }

    public void Tick(float dt)
    {
        if (State != ConditionState.Pending)
        {
            return;
        }

        if (_tag.Value == _expected)
        {
            State = ConditionState.Met;
            Debug.Log($"{_id}: [{State}]");
        }
    }
}
