using System.Collections.Generic;
using UnityEngine;

public class ScenarioBuilder
{
    private readonly DeviceRegistry _deviceRegistry;

    public ScenarioBuilder(DeviceRegistry deviceRegistry)
    {
        _deviceRegistry = deviceRegistry;
    }

    public ScenarioStep BuildStep(StepData step)
    {
        //Debug.Log(step.Conditions.Count);
        
        List<ICondition> conditions = new List<ICondition>(step.Conditions.Count);
        foreach (ConditionData item in step.Conditions)
        {
            //Debug.Log($"Try register condition: {item.Id} {item.DeviceTagPair.Device} - {item.DeviceTagPair.Tag}");
            IDevice device = _deviceRegistry.GetDeviceById(item.DeviceTagPair.Device);
            if (device == null)
            {
                continue;
            }
            //Debug.Log($"Device [{device.Id}]");

            //Debug.Log($"Tags: {device.Tags.Count}");
            //foreach (var item1 in device.Tags)
            //{
            //    Debug.Log($"Tag [{item1.Id}]");
            //}

            TagBase tag = device.GetTagById(item.DeviceTagPair.Tag);
            if(tag == null)
            {
                Debug.LogError($"Cant found tag {item.DeviceTagPair.Tag}");
                continue;
            }
            //Debug.Log($"Tag [{tag.Id}]");

            ICondition condition = BuildCondition(item,tag);
            conditions.Add(condition);
        }

        ScenarioStep scenarioStep = new ScenarioStep(conditions,step);

        return scenarioStep;
    }

    private ICondition BuildCondition(ConditionData condition, TagBase tag)
    {
        return condition.Type switch
        {
            ConditionType.Bool => new BoolCondition(condition.Id, (Tag<bool>)tag, condition.Expected),
            ConditionType.Range => new RangeCondition(condition.Id, (Tag<float>)tag, condition.Min, condition.Max),
            _ => throw new System.NotImplementedException()
        };
    }
}
