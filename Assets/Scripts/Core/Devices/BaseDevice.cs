using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class BaseDevice : MonoBehaviour, IDevice
{
    [SerializeField] private string id;

    public string Id => id;

    public abstract IReadOnlyCollection<TagBase> Tags { get; }

    public abstract void Tick(float deltaTime);

    public TagBase GetTagById(string id)
    {
        return Tags.FirstOrDefault(tag => tag.Id == id);
    }
}

public abstract class BaseFSMDevice<T> : BaseDevice where T : Enum
{
    [SerializeField] private T state;

    private Dictionary<PumpState, IPumpState> _states;

    private IPumpState _currentState;

    //public T State
    //{
    //    get
    //    {
    //        return state;
    //    }
    //    set
    //    {
    //        if (state != value)
    //        {
    //            state = value;
    //            ChangeState(state);
    //        }
    //    }
    //}

    //private void ChangeState(T newState)
    //{
    //    if (_currentState?.State == newState)
    //    {
    //        return;
    //    }

    //    _currentState?.Exit(this);

    //    _currentState = _states[newState];
    //    _currentState.Enter(this);
    //}
}