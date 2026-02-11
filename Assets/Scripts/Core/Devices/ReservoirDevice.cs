using System.Collections.Generic;
using UnityEngine;

public class ReservoirDevice : BaseDevice
{
    [SerializeField] private float capacity;

    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private float maxFill;

    public override IReadOnlyCollection<TagBase> Tags => new TagBase[] { FillLevel, Capacity };


    public Tag<float> FillLevel;
    public Tag<float> Capacity;


    private Tag<float> _inletFlow;
    private Tag<bool> _isValveOpen;

    public void Construct(Tag<float> inletFlow, Tag<bool> isValveOpen)
    {
        _inletFlow = inletFlow;
        _isValveOpen = isValveOpen;

        FillLevel = new Tag<float>("FillLevel", 0f);
        Capacity = new Tag<float>($"Capacity", capacity);
    }

    private void Start()
    {
        float normalized = Mathf.Clamp01(FillLevel.Value / capacity);
        spriteRenderer.size = new Vector2(spriteRenderer.size.x, maxFill * normalized);
    }

    public override void Tick(float deltaTime)
    {
        if (!_isValveOpen.Value)
        {
            return;
        }

        float delta = _inletFlow.Value * deltaTime;
        FillLevel.Value = Mathf.Clamp(FillLevel.Value + delta, 0f, Capacity.Value);

        float normalized = Mathf.Clamp01(FillLevel.Value / capacity);
        spriteRenderer.size = new Vector2(spriteRenderer.size.x, maxFill * normalized);
    }
}
