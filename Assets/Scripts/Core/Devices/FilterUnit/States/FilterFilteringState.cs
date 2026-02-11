using UnityEngine;

public class FilterFilteringState : IFilterState
{
    public FilterState State => FilterState.Filtering;


    public void Enter(FilterUnit device)
    {
        Debug.Log("Enter Filtering State");
    }

    public void Exit(FilterUnit device)
    {
        Debug.Log("Exit Filtering State");
    }

    public void Update(FilterUnit device, float dt)
    {
        //throw new System.NotImplementedException();
    }
}
