using System.Collections.Generic;

public abstract class BaseState<T> : IState, IEnterable, IExitable where T : BaseDevice
{
    protected readonly IEnumerable<IBehavior> _behaviors;
    protected readonly T _device;

    public BaseState(IEnumerable<IBehavior> behaviors, T device)
    {
        _behaviors = behaviors;
        _device = device;
    }

    public virtual void Enter()
    {
        EnableBehaviors();
    }

    public virtual void Exit()
    {
        DisableBehaviors();
    }

    private void EnableBehaviors()
    {
        foreach (var item in _behaviors)
        {
            item.Enable();
        }
    }

    private void DisableBehaviors()
    {
        foreach (var item in _behaviors)
        {
            item.Disable();
        }
    }
}
