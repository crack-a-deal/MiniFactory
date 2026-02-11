using UnityEngine;

public class FilterCloggedState : IFilterState
{
    public FilterState State => FilterState.Clogged;

    public void Enter(FilterUnit device)
    {
        Debug.Log("Enter Clogged State");
    }

    public void Exit(FilterUnit device)
    {
        Debug.Log("Exit Clogged State");
    }

    public void Update(FilterUnit device, float dt)
    {
        //throw new System.NotImplementedException();
    }
}
