public class PumpRunningState : IPumpState
{
    public PumpState State => PumpState.Running;

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
        pump.FlowRate.Value = pump.MaxFlowRate;
    }
}