using System.Collections.Generic;

public class PumpIdleState : BaseState<PumpDevice>, IUpdatable
{
    public PumpIdleState(IEnumerable<IBehavior> behaviors, PumpDevice device) : base(behaviors, device)
    {
    }

    public void Update(float deltaTime)
    {
        if (_device.IsOn.Value)
        {
            _device.ChangeState(PumpState.Running);
        }
    }
}
