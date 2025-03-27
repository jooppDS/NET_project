using task2.Interfaces;

namespace task2;

class Smartwatch : Device, IPowerNotifier
{
    private const string manType = "SW";
    
    long Power;

    public Smartwatch(string id, string name, bool active, long power) : base(id, name, active) {
        Power = power >= 0 & power <= 100 ? power : 0;
    }


    public override bool PowerOn() {
        bool success = Power > 11 ? true : false;
        if (success)
            Power -= 10;
        else
        {
            Notify();
            throw new EmptyBatteryException();
        }

        _active = success;
        return success;
    }

    public override bool Edit(Device otherDevice)
    {
        if (otherDevice is not Smartwatch newWatch)
            throw new ArgumentException();

        _id = newWatch._id;
        _name = newWatch._name;
        _active = newWatch._active;
        _power = newWatch._power;


        return true;
    }



    public long _power
    {
        get { return Power; }
        set { Power = value; }
    }

    public override string getFileFormat() {
        return manType + ',' + base.getFileFormat() + ',' +Power + '%';
    }
    
    public override string ToString()
    {
        return base.ToString() + "Power: " + Power + "\n";
    }
    

    public void Notify() {
       Console.WriteLine("Energy is low"); 
    }
}