using System.Collections.Generic;

public class ValveOpeningState : BaseState<ValveDevice>, IUpdatable
{
    public ValveOpeningState(IEnumerable<IBehavior> behaviors, ValveDevice device) : base(behaviors, device)
    {
        foreach (var item in behaviors)
        {
            if (item is BaseBehavior<ValveDevice> bb)
                bb.Initialize(device);
        }
    }

    public void Update(float deltaTime)
    {
        foreach (var item in _behaviors)
        {
            item.Tick(deltaTime);
        }

        if (_device.OpenPercent.Value >= 1)
        {
            _device.ChangeState(ValveState.Open);
        }
    }
}
