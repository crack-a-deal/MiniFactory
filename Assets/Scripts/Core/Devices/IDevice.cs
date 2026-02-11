using System.Collections.Generic;

public interface IDevice
{
    string Id { get; }
    IReadOnlyCollection<TagBase> Tags { get; }
    void Tick(float deltaTime);

    TagBase GetTagById(string id);
}
