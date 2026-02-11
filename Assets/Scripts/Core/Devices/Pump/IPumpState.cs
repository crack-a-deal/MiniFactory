public interface IPumpState : IState<PumpDevice>
{
    PumpState State { get; }
}
