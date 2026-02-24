public class ReservoirFillBehavior : BaseBehavior<ReservoirDevice>
{
    protected override void OnTick(float deltaTime)
    {
        float newFillLevel = _device.FillLevel.Value + _device.InputFlow.Value * deltaTime;
        _device.SetFillLevel(newFillLevel);
    }
}
