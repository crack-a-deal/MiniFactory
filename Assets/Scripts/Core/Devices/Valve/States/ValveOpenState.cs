using System.Collections.Generic;

public class ValveOpenState : BaseState<ValveDevice>
{
    public ValveOpenState(IEnumerable<IBehavior> behaviors, ValveDevice device) : base(behaviors, device)
    {
    }
}
