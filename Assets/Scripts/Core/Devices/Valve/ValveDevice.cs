using System.Collections.Generic;
using UnityEngine;

public class ValveDevice : BaseDevice<ValveState>
{
    [SerializeField] private DeviceButton button;

    public IState CurrentState => _stateMachine.CurrentState;

    public Tag<float> InputFlow;
    public Tag<float> OutputFlow;

    public Tag<float> OpenPercent;

    public override IReadOnlyCollection<TagBase> Tags => new TagBase[] { InputFlow, OutputFlow, OpenPercent };

    public void Construct(Tag<float> inputFlow)
    {
        InputFlow = inputFlow;

        OutputFlow = new Tag<float>($"OutputFlow", 0f);
        OpenPercent = new Tag<float>($"Open", 0f);
    }

    private void Start()
    {
        button.Clicked += Button_Clicked;
    }

    public override void Tick(float deltaTime)
    {
        _stateMachine.Update(deltaTime);
    }

    public void SetOpenPercent(float percent)
    {
        OpenPercent.Value = Mathf.Clamp01(percent);
    }

    public void UpdateFlow()
    {
        OutputFlow.Value = InputFlow.Value * OpenPercent.Value;
    }

    public void ChangeState(ValveState newState)
    {
        if (_states.ContainsKey(newState))
        {
            _stateMachine.ChangeState(_states[newState]);
        }
    }

    private void Button_Clicked()
    {
        if (_stateMachine.CurrentState is ValveClosedState)
        {
            ChangeState(ValveState.Opening);
        }
        else if (_stateMachine.CurrentState is ValveOpenState)
        {
            ChangeState(ValveState.Closing);
        }
    }

    protected override IState CreateState(ValveState state)
    {
        return state switch
        {
            ValveState.Closed => new ValveClosedState(_stateBehaviors[ValveState.Closed], this),
            ValveState.Opening => new ValveOpeningState(_stateBehaviors[ValveState.Opening], this),
            ValveState.Open => new ValveOpenState(_stateBehaviors[ValveState.Open], this),
            ValveState.Closing => new ValveClosingState(_stateBehaviors[ValveState.Closing], this),
            _ => throw new System.NotImplementedException()
        };
    }
}
