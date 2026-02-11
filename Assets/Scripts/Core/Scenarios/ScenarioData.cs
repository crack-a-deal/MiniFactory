using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SCADA/Scenario")]
public class ScenarioData : ScriptableObject
{
    public List<StepData> Steps;
}

[System.Serializable]
public class StepData
{
    public string Id;
    public string Description;
    public StepCompeteCondition CompeteCondition;
    public List<ConditionData> Conditions;
}

public enum StepCompeteCondition
{
    All,
    Any,
}

public enum ConditionType
{
    Bool,
    Range,
}

[System.Serializable]
public class ConditionData
{
    public string Id;
    public DeviceTagPair DeviceTagPair;
    public ConditionType Type;

    [Header("Bool Condition")]
    public bool Expected;

    [Header("Range Condition")]
    public float Min;
    public float Max;
}

[System.Serializable]
public class DeviceTagPair
{
    public string Device;
    public string Tag;
}