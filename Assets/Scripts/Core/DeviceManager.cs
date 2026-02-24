using System.Collections.Generic;
using UnityEngine;

public class DeviceManager : MonoBehaviour
{
    [SerializeField] private PumpDevice pump;
    [SerializeField] private ValveDevice valve;
    [SerializeField] private ReservoirDevice reservoir;

    private List<IDevice> _devices;

    private void Awake()
    {
        pump.Construct();
        valve.Construct(pump.FlowRate);
        reservoir.Construct(valve.OutputFlow);
    }

    private void Start()
    {
        _devices = new List<IDevice>
        {
            pump,
            valve,
            reservoir
        };
    }

    private void Update()
    {
        float dt = Time.deltaTime;
        foreach (IDevice device in _devices)
        {
            device.Tick(dt);
        }
    }
}
