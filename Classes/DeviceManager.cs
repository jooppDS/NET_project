
using System.Runtime.Loader;
using System.Text.RegularExpressions;
using task2.Interfaces;

namespace task2;

public class DeviceManager : IDeviceManager, IDeviceController
{

    private List<Device> deviceStorage = new List<Device>();

    private IFileManager fileManager;



    public DeviceManager(string filePath)
    {
        fileManager = new FIleHandler();
        deviceStorage = fileManager.loadFile(filePath);
    }

    public bool addDevice(Device device)
    {
        if (deviceStorage.Count >= 15)
            Console.WriteLine("Storage is full");
        else
        {
            deviceStorage.Add(device);
            Console.WriteLine("Device added");
            return true;
        }

        return false;
    }



    public Device findDevice(string id)
    {
        foreach (Device device in deviceStorage)
        {
            if (device._id == id)
                return device;
        }

        return null;
    }

    public bool removeDevice(string id)
    {
        Device device = findDevice(id);
        if (device != null)
            deviceStorage.Remove(findDevice(id));
        else
        {
            Console.WriteLine("Device not found");
            return false;
        }

        Console.WriteLine("Device removed");
        return true;
    }

    public bool editDevice(Device device, string id)
    {
        Device oldDevice = findDevice(id);
        if (oldDevice == null)
            return false;
        try
        {
            oldDevice.Edit(device);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return false;
        }

        return true;
    }


    public void turnOn(string id)
    {
        Device device = findDevice(id);
        try
        {
            device.PowerOn();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public void turnOff(string id)
    {
        Device device = findDevice(id);
        device.PowerOff();
    }

    public override string ToString()
    {
        string output = "";
        foreach (Device device in deviceStorage)
            output += device.ToString();
        return output;
    }


    public bool saveStorage(string path) {
        return fileManager.saveFile(path, deviceStorage);
    }
}
