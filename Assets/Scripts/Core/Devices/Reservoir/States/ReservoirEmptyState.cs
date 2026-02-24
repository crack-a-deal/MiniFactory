using System.Collections.Generic;

public class ReservoirEmptyState : BaseState<ReservoirDevice>, IUpdatable
{
    public ReservoirEmptyState(IEnumerable<IBehavior> behaviors, ReservoirDevice device) : base(behaviors, device)
    {
    }

    public void Update(float deltaTime)
    {
        if (_device.InputFlow.Value > 0)
        {
            _device.ChangeState(ReservoirState.Filling);
        }
    }
}
