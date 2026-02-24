using System;
using UnityEngine;

[Serializable]
public class BaseStateBehaviorPair<T> where T : Enum
{
    public T State;
    [SerializeReference] public BaseBehavior[] Behaviors;
}
