using System.Collections.Generic;

public class ReservoirFilledState : BaseState<ReservoirDevice>, IUpdatable
{
    public ReservoirFilledState(IEnumerable<IBehavior> behaviors, ReservoirDevice device) : base(behaviors, device)
    {
    }

    public void Update(float deltaTime)
    {
        _device.ChangeState(ReservoirState.Draining);
    }
}
