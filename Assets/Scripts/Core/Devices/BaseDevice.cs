using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class BaseDevice : MonoBehaviour, IDevice
{
    [SerializeField] private string id;

    public string Id => id;

    public abstract IReadOnlyCollection<TagBase> Tags { get; }

    protected StateMachine _stateMachine;

    protected virtual void Awake()
    {
        _stateMachine = new StateMachine();
    }

    public abstract void Tick(float deltaTime);

    public TagBase GetTagById(string id)
    {
        return Tags.FirstOrDefault(tag => tag.Id == id);
    }
}

public abstract class BaseDevice<TState> : BaseDevice where TState : Enum
{
    [SerializeField] private BaseStateBehaviorPair<TState>[] behaviors;
    [SerializeField] private TState initialState;

    protected Dictionary<TState, IState> _states;
    protected Dictionary<TState, BaseBehavior[]> _stateBehaviors;

    protected override void Awake()
    {
        base.Awake();

        BuildBehaviors();
        BuildStates();

        if (_states.TryGetValue(initialState, out IState state))
        {
            _stateMachine.ChangeState(state);
        }
    }

    private void BuildBehaviors()
    {
        _stateBehaviors = new Dictionary<TState, BaseBehavior[]>(behaviors.Length);

        foreach (BaseStateBehaviorPair<TState> pair in behaviors)
        {
            _stateBehaviors[pair.State] = pair.Behaviors;
        }
    }

    private void BuildStates()
    {
        _states = new Dictionary<TState, IState>(Enum.GetNames(typeof(TState)).Length);

        foreach (BaseStateBehaviorPair<TState> pair in behaviors)
        {
            _states[pair.State] = CreateState(pair.State);
        }
    }

    protected abstract IState CreateState(TState state);
}