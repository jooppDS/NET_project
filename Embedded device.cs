using System.Text.RegularExpressions;

namespace task2;

class EmbededDevice : Device
{

    private const string manType = "ED";
    
    private string Ip;
    private string networkName;

    public EmbededDevice(long id, string name, bool active, string ip, string networkname) : base(id, name, active)
    {
        try
        {
            _ip = ip;
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }

        this.networkName = networkname;
    }



    private void Connect()  
    {
        Regex rg = new Regex("MD Ltd.”");
        if(!rg.IsMatch(networkName))
            throw new ConnectionException();
    }

    public bool PowerOn() {
        try
        {
            Connect();
        }
        catch (ConnectionException ex)
        {
            Console.WriteLine(ex.Message);
        }

        _active = true;
        return _active;
    }

    public void PowerOff() {
        _active = false;
    }

    public string _networkname
    {
        get { return networkName; }
        set { networkName = value; }
    }

    public string _ip {
        get { return Ip; }
        set
        {
                Regex rg = new Regex("([0-9]+.*)+");
                if (rg.IsMatch(value))
                    Ip = value;
                else
                    throw new ArgumentException();
        }
    }
    public string getFileFormat()
    {
        return manType + ',' + base.getFileFormat() + Ip + ',' + networkName;
    }
    
    public override string ToString()
    {
        return base.ToString() + "IP: " + _ip + "\n" + "NET: " + _networkname + "\n";
    }
}