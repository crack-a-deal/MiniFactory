using System.Collections.Generic;
using UnityEngine;

public class Simulation : MonoBehaviour
{
    [SerializeField] private PumpDevice pump;
    [SerializeField] private ValveDevice valve;
    [SerializeField] private ReservoirDevice reservoir;
    [SerializeField] private FilterUnit filter;

    private List<IDevice> _devices;

    private void Awake()
    {
        pump.Construct();
        valve.Construct();
        filter.Construct(pump.FlowRate);
        reservoir.Construct(pump.FlowRate, valve.IsOpen);
    }

    private void Start()
    {
        _devices = new List<IDevice>
        {
            pump,
            valve,
            filter,
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
