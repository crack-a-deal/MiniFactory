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
    private bool _isEnabled;

    public void Initialize(TDevice device)
    {
        _device = device;
    }

    public override void Enable()
    {
        _isEnabled = true;
    }

    public override void Disable()
    {
        _isEnabled = false;
    }

    public override void Tick(float deltaTime)
    {
        if (!_isEnabled)
        {
            return;
        }

        OnTick(deltaTime);
    }
    
    protected abstract void OnTick(float deltaTime);
}
