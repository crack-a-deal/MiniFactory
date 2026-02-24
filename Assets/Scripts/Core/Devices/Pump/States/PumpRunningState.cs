using System.Collections.Generic;

public class PumpRunningState : BaseState<PumpDevice>, IUpdatable
{
    public PumpRunningState(IEnumerable<IBehavior> behaviors, PumpDevice device) : base(behaviors, device)
    {
    }

    public void Update(float deltaTime)
    {
        _device.FlowRate.Value = _device.MaxFlowRate;
    }
}