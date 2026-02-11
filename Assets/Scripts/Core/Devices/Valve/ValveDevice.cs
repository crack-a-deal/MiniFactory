using System.Collections.Generic;
using UnityEngine;

public class ValveDevice :BaseDevice
{
    [SerializeField] private DeviceButton button;

    public override IReadOnlyCollection<TagBase> Tags => new TagBase[] { IsOpen };

    public Tag<bool> IsOpen;

    public void Construct()
    {
        IsOpen = new Tag<bool>($"IsOpen", false);
    }

    private void Start()
    {
        button.Clicked += Button_Clicked;
    }

    public override void Tick(float deltaTime)
    {
    }

    private void Button_Clicked()
    {
        IsOpen.Value = !IsOpen.Value;
    }
}
