using UnityEngine;

public class RangeCondition : ICondition
{
    private readonly string _id;
    private readonly Tag<float> _tag;
    private readonly float _min;
    private readonly float _max;

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

    public RangeCondition(string id, Tag<float> tag, float min, float max)
    {
        _id = id;
        _tag = tag;
        _min = min;
        _max = max;
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

        if (_tag.Value >= _min && _tag.Value <= _max)
        {
            State = ConditionState.Met;
            Debug.Log($"{_id}: [{State}]");
        }
    }
}