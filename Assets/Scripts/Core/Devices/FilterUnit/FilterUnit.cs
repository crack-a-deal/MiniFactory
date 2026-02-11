using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.Port;

public class FilterUnit : BaseDevice
{
    //MechanicalFilter
    //CarbonFilter

    [SerializeField] private FilterState state;
    public FilterState State
    {
        get
        {
            return state;
        }
        set
        {
            if( state != value)
            {
                state = value;
                ChangeState(state);
            }
        }
    }

    public Tag<float> InletFlowRate;
    //public Tag<float> Efficiency;
    //public Tag<float> CloggingLevel;



    public override IReadOnlyCollection<TagBase> Tags => throw new System.NotImplementedException();

    private Dictionary<FilterState, IFilterState> _states;

    private IFilterState _currentState;

    public void Construct(Tag<float> inletFlow)
    {
        InletFlowRate = inletFlow;

        //FillLevel = new Tag<float>("FillLevel", 0f);
        //Capacity = new Tag<float>($"Capacity", capacity);
    }

    private void Awake()
    {
        _states = new Dictionary<FilterState, IFilterState>
        {
            { FilterState.Idle, new FilterIdleState() },
            { FilterState.Filtering, new FilterFilteringState() },
            { FilterState.Clogged, new FilterCloggedState() }
        };

        ChangeState(state);
    }

    public override void Tick(float deltaTime)
    {
        _currentState.Update(this, deltaTime);
    }

    private void ChangeState(FilterState newState)
    {
        if (_currentState?.State == newState)
        {
            return;
        }

        _currentState?.Exit(this);

        _currentState = _states[newState];
        _currentState.Enter(this);
    }
}
