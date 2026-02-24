public abstract class BaseCondition : ICondition
{
    private readonly string _id;
    public string Id => _id;

    private ConditionState _state = ConditionState.Inactive;

    public ConditionState State
    {
        get
        {
            return _state;
        }
        set
        {
            if (_state != value)
            {
                _state = value;
            }
        }
    }

    public BaseCondition(string id)
    {
        _id = id;
    }

    public void Activate()
    {
        State = ConditionState.Pending;
    }

    public void Deactivate()
    {
        State = ConditionState.Inactive;
    }

    public void Tick(float deltaTime)
    {
        if (_state != ConditionState.Pending)
        {
            return;
        }
        if (CheckCondition())
        {
            State = ConditionState.Met;
        }
    }

    protected abstract bool CheckCondition();
}
