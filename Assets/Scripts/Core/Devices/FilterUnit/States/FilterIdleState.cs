using UnityEngine;

public class FilterIdleState : IFilterState
{
    public FilterState State => FilterState.Idle;

    public void Enter(FilterUnit device)
    {
        Debug.Log("Enter Idle State");
    }

    public void Update(FilterUnit device, float dt)
    {
        if (device.InletFlowRate.Value > 0)
        {
            device.State = FilterState.Filtering;
        }
    }

    public void Exit(FilterUnit device)
    {
        Debug.Log("Exit Idle State");
    }
}
