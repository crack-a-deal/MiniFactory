[System.Serializable]
public abstract class BaseBehavior : IBehavior
{
    public abstract void Enable();
    public abstract void Disable();
    public abstract void Tick(float deltaTime);
}


public abstract class BaseBehavior<TDevice> : BaseBehavior where TDevice : IDevice
{
    protected TDevice _device;

    public void Initialize(TDevice device)
    {
        _device = device;
    }
}
