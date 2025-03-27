using System.Text.RegularExpressions;
using task2.Interfaces;

namespace task2;

public class FIleHandler : IFileManager
{
    
    
    
    private int counter = 0;
    
    public List<Device> loadFile(string path)
    {
        if (File.Exists(path))
        {
            List<Device> devices = new List<Device>();
            string[] lines = File.ReadAllLines(path);
            Regex rg = new Regex("(\\S+,*)");
            foreach (string line in lines) {
                if (rg.IsMatch(line)) {
                    ++counter;
                    String id = counter.ToString();
                    string[] values = line.Split(',');
                    if (values[0].Contains("SW"))
                    {
                        bool status = bool.Parse(values[2]);
                        long power = long.Parse(values[3].Substring(0, values[3].Length - 1));
                        devices.Add(new Smartwatch(id, values[1], status, power));
                    }
                    else if (values[0].Contains('P')) {
                        bool status = bool.Parse(values[2]);
                        if(values.Length == 4)
                            devices.Add(new PersonalComputer(id, values[1], status, values[3]));
                        else
                            devices.Add(new PersonalComputer(id, values[1], status));
                    }
                    else if (values[0].Contains("ED"))
                    {
                        try
                        {
                            devices.Add(new EmbededDevice(id, values[1], false, values[2],
                                values[3]));
                        }
                        catch (ArgumentException ex) {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
            }
            return devices;
        }

        return null;
    }
    

    public bool saveFile(string path, List<Device> deviceStorage)
    {
        if(File.Exists(path))
            File.Delete(path);
        
        foreach (Device device in deviceStorage)
        {
            File.AppendAllText(path, device.getFileFormat()+'\n');
        }
        
        return true;
    }
}