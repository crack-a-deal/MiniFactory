public class ValveCloseState : IValveState
{
    public ValveState State => ValveState.Closed;

    public void Enter(ValveDevice device)
    {
        //throw new System.NotImplementedException();
    }

    public void Exit(ValveDevice device)
    {
        //throw new System.NotImplementedException();
    }

    public void Update(ValveDevice device, float dt)
    {
        //throw new System.NotImplementedException();
    }
}
