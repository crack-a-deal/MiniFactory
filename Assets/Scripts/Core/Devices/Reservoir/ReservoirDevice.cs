using System.Collections.Generic;
using UnityEngine;

public class ReservoirDevice : BaseDevice<ReservoirState>
{
    [SerializeField] private float capacity;

    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private float maxFill;

    public IState CurrentState => _stateMachine.CurrentState;


    public Tag<float> InputFlow;

    public Tag<float> FillLevel;
    public Tag<float> Capacity;

    public override IReadOnlyCollection<TagBase> Tags => new TagBase[] { FillLevel, Capacity };


    public void Construct(Tag<float> inputFlow)
    {
        InputFlow = inputFlow;

        FillLevel = new Tag<float>("FillLevel", 0f);
        Capacity = new Tag<float>($"Capacity", capacity);
    }

    private void Start()
    {
        SetFillLevel(0f);
    }

    public override void Tick(float deltaTime)
    {
        _stateMachine.Update(deltaTime);
    }

    public void SetFillLevel(float fillLevel)
    {
        FillLevel.Value = Mathf.Clamp(fillLevel, 0f, Capacity.Value);
        float normalized = Mathf.Clamp01(FillLevel.Value / capacity);
        spriteRenderer.size = new Vector2(spriteRenderer.size.x, maxFill * normalized);
    }

    public void ChangeState(ReservoirState newState)
    {
        if (_states.ContainsKey(newState))
        {
            _stateMachine.ChangeState(_states[newState]);
        }
    }

    protected override IState CreateState(ReservoirState state)
    {
        return state switch
        {
            ReservoirState.Empty => new ReservoirEmptyState(_stateBehaviors[state], this),
            ReservoirState.Filling => new ReservoirFillingState(_stateBehaviors[state], this),
            ReservoirState.Filled => new ReservoirFilledState(_stateBehaviors[state], this),
            ReservoirState.Draining => new ReservoirDrainingState(_stateBehaviors[state], this),
            _ => throw new System.NotImplementedException()
        };
    }
}
