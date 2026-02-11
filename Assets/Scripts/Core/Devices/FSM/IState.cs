public interface IState<T> where T : BaseDevice
{
    void Enter(T device);
    void Update(T device, float dt);
    void Exit(T device);
}
