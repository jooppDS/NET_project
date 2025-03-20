
using System.Text.RegularExpressions;

namespace task2;

public class Devicemanager {

    List<Device> deviceStorage = new List<Device>();

    private long counter = 0;

    public Devicemanager()
    {
    }

    public Devicemanager(string filePath)
    {
        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            Regex rg = new Regex("(\\S+,*)");
            foreach (string line in lines) {
                if (rg.IsMatch(line)) {
                    string[] values = line.Split(',');
                    if (values[0].Contains("SW"))
                    {
                        bool status = bool.Parse(values[2]);
                        long power = long.Parse(values[3].Substring(0, values[3].Length - 1));
                        deviceStorage.Add(new Smartwatch(++counter, values[1], status, power));
                    }
                    else if (values[0].Contains('P')) {
                        bool status = bool.Parse(values[2]);
                        if(values.Length == 4)
                            deviceStorage.Add(new PersonalComputer(++counter, values[1], status, values[3]));
                        else
                            deviceStorage.Add(new PersonalComputer(++counter, values[1], status));
                    }
                    else if (values[0].Contains("ED"))
                    {
                        try
                        {
                            deviceStorage.Add(new EmbededDevice(++counter, values[1], false, values[2],
                                values[3]));
                        }
                        catch (ArgumentException ex) {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
            }
        }
    }

    public bool addDevice(Device device) {
        if(deviceStorage.Count >= 15)
            Console.WriteLine("Storage is full");
        else
        {
            deviceStorage.Add(device);
            Console.WriteLine("Device added");
            return true;
        }

        return false;
    }



    private Device findDevice(long id) {
        foreach (Device device in deviceStorage) {
            if(device._id == id)
                return device;
        }

        return null;
    }

    public bool removeDevice(long id) {
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

    public bool editDevice(Device device, long id)
    {
        Device oldDevice = findDevice(id);
        if (oldDevice == null)
            return false;
        try
        {
            if (device is PersonalComputer & oldDevice is PersonalComputer)
            {


                PersonalComputer newComputer = (PersonalComputer)device;
                PersonalComputer oldComputer = (PersonalComputer)oldDevice;

                oldComputer._name = newComputer._name;
                oldComputer._active = newComputer._active;
                oldComputer._os = newComputer._os;


            }
            else if (device is Smartwatch & oldDevice is Smartwatch)
            {
                var newWatch = (Smartwatch)device;
                var oldWatch = (Smartwatch)oldDevice;
                oldWatch._name = newWatch._name;
                oldWatch._active = newWatch._active;
                oldWatch._power = newWatch._power;
            }
            else if (device is EmbededDevice & oldDevice is EmbededDevice)
            {
                var newED = (EmbededDevice)device;
                var oldED = (EmbededDevice)oldDevice;
                oldED._name = newED._name;
                oldED._active = newED._active;
                oldED._ip = newED._ip;
                oldED._networkname = newED._networkname;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return false;
        }

        return true;
    }


    public void turnOn(long id) {
        Device device = findDevice(id);
        try
        {


            if (device is PersonalComputer)
            {
                PersonalComputer deviceComputer = (PersonalComputer)device;
                deviceComputer.PowerOn();
            }
            else if (device is Smartwatch)
            {
                Smartwatch deviceSmartwatch = (Smartwatch)device;
                deviceSmartwatch.PowerOn();
            }
            else if (device is EmbededDevice)
            {
                EmbededDevice deviceEmbeded = (EmbededDevice)device;
                deviceEmbeded.PowerOn();
            }
        }
        catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }

    public void turnOff(long id)
    {
        Device device = findDevice(id);
        if (device is PersonalComputer) {
            PersonalComputer deviceComputer = (PersonalComputer)device;
            deviceComputer.powerOff();
        }
        else if (device is Smartwatch) {
            Smartwatch deviceSmartwatch = (Smartwatch)device;
            deviceSmartwatch.PowerOff();
        }
        else if (device is EmbededDevice) {
            EmbededDevice deviceEmbeded = (EmbededDevice)device;
            deviceEmbeded.PowerOff();
        }
    }

    public void saveStorage(string filename)
    {
        foreach (Device device in deviceStorage)
        {
            
            if (device is PersonalComputer) {
                PersonalComputer deviceComputer = (PersonalComputer)device;
                File.AppendAllText(filename, deviceComputer.getFileFormat()+'\n');
            }
            else if (device is Smartwatch) {
                Smartwatch deviceSmartwatch = (Smartwatch)device;
                File.AppendAllText(filename, deviceSmartwatch.getFileFormat()+'\n');
            }
            else if (device is EmbededDevice) {
                EmbededDevice deviceEmbeded = (EmbededDevice)device;
                File.AppendAllText(filename, deviceEmbeded.getFileFormat()+'\n');
            }
    

        }
    }

    public override string ToString()
    {
        string output = "";
        foreach (Device device in deviceStorage)
            output += device.ToString();
        return output;
    }
}