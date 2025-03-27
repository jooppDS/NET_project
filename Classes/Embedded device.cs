using System.Text.RegularExpressions;

namespace task2;

class EmbededDevice : Device
{

    private const string manType = "ED";
    
    private string Ip;
    private string networkName;

    public EmbededDevice(string id, string name, bool active, string ip, string networkname) : base(id, name, active)
    {
        try
        {
            _ip = ip;
            _networkname = networkname;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        
    }



    private void Connect()  
    {
        Regex rg = new Regex("MD Ltd.”");
        if(!rg.IsMatch(networkName))
            throw new ConnectionException();
    }

    public override bool PowerOn() {
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

    public override bool Edit(Device otherDevice)
    {
        if (otherDevice is not EmbededDevice newED)
            throw new ArgumentException();

        _id = newED._id;
        _name = newED._name;
        _active = newED._active;
        _ip = newED._ip;
        _networkname = newED._networkname;


        return true;
    }


    public string _networkname
    {
        get { return networkName; }
        set
        {
            Regex rg = new Regex("MD Ltd.");
            if(rg.IsMatch(value))
                networkName = value;
            else
                throw new ConnectionException();
        }
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
    public override string getFileFormat()
    {
        return manType + ',' + _name + ',' + Ip + ',' + networkName;
    }
    
    public override string ToString()
    {
        return base.ToString() + "IP: " + _ip + "\n" + "NET: " + _networkname + "\n";
    }
}