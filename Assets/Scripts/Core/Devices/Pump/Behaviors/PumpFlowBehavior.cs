using UnityEngine;

[System.Serializable]
public class PumpFlowBehavior : BaseBehavior<PumpDevice>
{
    [SerializeField] private float flowRateChangePerSecond;

    protected override void OnTick(float deltaTime)
    {
        float newFlowRate = _device.FlowRate.Value + flowRateChangePerSecond * deltaTime;
        _device.SetFlow(newFlowRate);
    }
}