using System.Collections.Generic;
using UnityEngine;

public class ValveClosedState : BaseState<ValveDevice>
{
    public ValveClosedState(IEnumerable<IBehavior> behaviors, ValveDevice device) : base(behaviors, device)
    {
    }
}
