public class StateMachine
{
    private IState _currentState;

    public IState CurrentState => _currentState;

    public void ChangeState(IState newState)
    {
        if (_currentState == newState)
        {
            return;
        }

        if (_currentState is IExitable exitableState)
        {
            exitableState.Exit();
        }

        _currentState = newState;

        if (_currentState is IEnterable enterableState)
        {
            enterableState.Enter();
        }
    }

    public void Update(float deltaTime)
    {
        if (_currentState == null)
        {
            return;
        }

        if (_currentState is IUpdatable updatableState)
        {
            updatableState.Update(deltaTime);
        }
    }
}
