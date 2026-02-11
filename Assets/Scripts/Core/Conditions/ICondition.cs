public interface ICondition
{
    string Id { get; }
    ConditionState State { get; set; }

    void Activate();
    void Deactivate();
    void Tick(float dt);
}
