using System.Collections.Generic;
using UnityEngine;

public class PumpDevice : BaseDevice
{
    [SerializeField] private float maxFlowRate;

    [SerializeField] private DeviceButton button;

    [SerializeField] private PumpState state;


    public PumpState State
    {
        get
        {
            return state;
        }
        set
        {
            if (state != value)
            {
                state = value;
                ChangeState(state);
            }
        }
    }

    public float MaxFlowRate => maxFlowRate;

    public Tag<bool> IsOn;
    public Tag<float> FlowRate;

    private Dictionary<PumpState, IPumpState> _states;

    private IPumpState _currentState;

    public override IReadOnlyCollection<TagBase> Tags => new TagBase[] { IsOn, FlowRate };

    public void Construct()
    {
        IsOn = new Tag<bool>($"IsOn", false);
        FlowRate = new Tag<float>($"FlowRate", 0f);
    }

    private void Awake()
    {
        _states = new Dictionary<PumpState, IPumpState>
        {
            { PumpState.Off, new PumpOffState() },
            { PumpState.Running, new PumpRunningState() },
        };

        ChangeState(state);
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
        _currentState.Update(this, deltaTime);

        //FlowRate.Value = IsOn.Value ? maxFlowRate : 0f;
    }

    private void ChangeState(PumpState newState)
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
