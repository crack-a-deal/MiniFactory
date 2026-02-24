using System.Collections.Generic;

public class ValveClosingState : BaseState<ValveDevice>, IUpdatable
{
    public ValveClosingState(IEnumerable<IBehavior> behaviors, ValveDevice device) : base(behaviors, device)
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

        if (_device.OpenPercent.Value <= 0)
        {
            _device.ChangeState(ValveState.Closed);
        }
    }
}