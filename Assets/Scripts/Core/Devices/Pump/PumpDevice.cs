using System;
using System.Collections.Generic;
using UnityEngine;

public class PumpDevice : BaseDevice<PumpState>
{
    [SerializeField] private float maxFlowRate;
    [SerializeField] private DeviceButton button;

    public float MaxFlowRate => maxFlowRate;

    public Tag<bool> IsOn;
    public Tag<float> FlowRate;

    public override IReadOnlyCollection<TagBase> Tags => new TagBase[] { IsOn, FlowRate };

    public void Construct()
    {
        IsOn = new Tag<bool>($"IsOn", false);
        FlowRate = new Tag<float>($"FlowRate", 0f);
    }

    private void Start()
    {
        button.Clicked += Button_Clicked;
    }

    private void Button_Clicked()
    {
        IsOn.Value = !IsOn.Value;
    }

    public override void Tick(float deltaTime)
    {
        _stateMachine.Update(deltaTime);
    }

    public void ChangeState(PumpState newState)
    {
        if (_states.ContainsKey(newState))
        {
            _stateMachine.ChangeState(_states[newState]);
        }
    }

    protected override IState CreateState(PumpState state)
    {
        return state switch
        {
            PumpState.Idle => new PumpIdleState(_stateBehaviors[PumpState.Idle], this),
            PumpState.Running =>
            new PumpRunningState(_stateBehaviors[PumpState.Running], this),
            _ => throw new NotImplementedException()
        };
    }

    public void SetFlow(float flowRate)
    {
        FlowRate.Value = Mathf.Clamp(flowRate, 0f, MaxFlowRate);
    }
}
