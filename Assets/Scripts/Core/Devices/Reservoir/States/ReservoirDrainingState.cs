using System.Collections.Generic;

public class ReservoirDrainingState : BaseState<ReservoirDevice>, IUpdatable
{
    public ReservoirDrainingState(IEnumerable<IBehavior> behaviors, ReservoirDevice device) : base(behaviors, device)
    {
        foreach (var item in behaviors)
        {
            if (item is BaseBehavior<ReservoirDevice> bb)
                bb.Initialize(device);
        }
    }

    public void Update(float deltaTime)
    {
        foreach (var item in _behaviors)
        {
            item.Tick(deltaTime);
        }

        if (_device.FillLevel.Value <= 0)
        {
            _device.ChangeState(ReservoirState.Empty);
        }
    }
}