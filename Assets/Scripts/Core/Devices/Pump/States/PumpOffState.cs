public class PumpOffState : IPumpState
{
    public PumpState State => PumpState.Off;

    public void Enter(PumpDevice pump)
    {
        //throw new System.NotImplementedException();
    }

    public void Exit(PumpDevice pump)
    {
        //throw new System.NotImplementedException();
    }

    public void Update(PumpDevice pump, float dt)
    {
        if (pump.IsOn.Value)
        {
            pump.State = PumpState.Running;
        }
    }
}
