using task2.Interfaces;

namespace task2;

class Smartwatch : Device, IPowerNotifier
{
    private const string manType = "SW";
    
    long Power;

    public Smartwatch(long id, string name, bool active, long power) : base(id, name, active) {
        Power = power >= 0 & power <= 100 ? power : 0;
    }


    public bool PowerOn() {
        bool success = Power > 11 ? true : false;
        if (success)
            Power -= 10;
        else
            throw new EmptyBatteryException();
        _active = success;
        return success;
    }

    public void PowerOff() {
        _active = false;
    }

    public long _power
    {
        get { return Power; }
        set { Power = value; }
    }

    public string getFileFormat() {
        return manType + ',' + base.getFileFormat() + Power + '%';
    }
    
    public override string ToString()
    {
        return base.ToString() + "Power: " + Power + "\n";
    }
}