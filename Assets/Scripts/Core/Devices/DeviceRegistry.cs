using System.Collections.Generic;
using UnityEngine;

public class DeviceRegistry
{
    private List<BaseDevice> _devices;
    private Dictionary<string, IDevice> _devicesByName;

    public DeviceRegistry(List<BaseDevice> devices)
    {
        _devices = devices;
        _devicesByName = new Dictionary<string, IDevice>();
        foreach (IDevice device in _devices)
        {
            _devicesByName.Add(device.Id, device);
        }
    }

    public IDevice GetDeviceById(string id)
    {
        if(_devicesByName.TryGetValue(id, out IDevice device))
        {
            return device;
        }

        Debug.LogError($"Can't found device by id [{id}]");
        return null;
    }
}