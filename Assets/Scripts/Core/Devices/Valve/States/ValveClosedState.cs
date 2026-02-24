using System.Collections.Generic;

public class ValveClosedState : BaseState<ValveDevice>
{
    public ValveClosedState(IEnumerable<IBehavior> behaviors, ValveDevice device) : base(behaviors, device)
    {
    }
}
