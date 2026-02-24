using UnityEngine;

public class ReservoirDrainBehavior : BaseBehavior<ReservoirDevice>
{
    [SerializeField] private float drainRate;

    protected override void OnTick(float deltaTime)
    {
        float newFillLevel = _device.FillLevel.Value - drainRate * deltaTime;
        _device.SetFillLevel(newFillLevel);
    }
}