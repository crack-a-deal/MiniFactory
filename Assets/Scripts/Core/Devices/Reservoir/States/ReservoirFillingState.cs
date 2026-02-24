using System.Collections.Generic;

public class ReservoirFillingState : BaseState<ReservoirDevice>, IUpdatable
{
    public ReservoirFillingState(IEnumerable<IBehavior> behaviors, ReservoirDevice device) : base(behaviors, device)
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

        if (_device.FillLevel.Value >= _device.Capacity.Value)
        {
            _device.ChangeState(ReservoirState.Filled);
        }
    }
}
