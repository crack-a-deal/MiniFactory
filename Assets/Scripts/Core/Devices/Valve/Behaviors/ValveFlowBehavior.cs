using UnityEngine;

public class ValveFlowBehavior : BaseBehavior<ValveDevice>
{
    [SerializeField] private float openingSpeed;

    protected override void OnTick(float deltaTime)
    {
        float newOpenPercent = _device.OpenPercent.Value + openingSpeed * deltaTime;
        _device.SetOpenPercent(newOpenPercent);
        _device.UpdateFlow();
    }
}
