namespace task2;

public class DMFactory
{
    public DeviceManager CreateDM(String path)
    {
        return new DeviceManager(path);
    }
}