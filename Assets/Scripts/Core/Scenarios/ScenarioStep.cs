using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum StepState
{
    Idle,
    Active,
    Completed,
    Failed,
}


public class ScenarioStep
{
    private StepState _state;
    private readonly List<ICondition> _conditions;
    private readonly StepData _step;

    public StepState State => _state;

    public ScenarioStep(List<ICondition> conditions, StepData step)
    {
        _state = StepState.Idle;
        _conditions = conditions;
        _step = step;
    }

    public void Activate()
    {
        _state = StepState.Active;
        Debug.Log($"Start Step [{_step.Id}]: with [{_conditions.Count}] conditions ");

        foreach (var item in _conditions)
        {
            item.Activate();
        }
    }

    public void Deactivate()
    {
        _state = StepState.Idle;
    }

    public void Tick(float dt)
    {
        if(_state != StepState.Active)
        {
            return;
        }

        foreach (ICondition condition in _conditions)
        {
            condition.Tick(dt);
        }

        if (CheckConditionComplete())
        {
            _state = StepState.Completed;
            Debug.Log($"{_step.Id} Completed");
            Deactivate();
        }
    }

    private bool CheckConditionComplete()
    {
        switch (_step.CompeteCondition)
        {
            case StepCompeteCondition.All:
                {
                    return _conditions.All(condition => condition.State == ConditionState.Met);
                }
            case StepCompeteCondition.Any:
                {
                    return _conditions.Any(condition => condition.State == ConditionState.Met);
                }

            default:
                break;
        }

        return false;
    }
}
