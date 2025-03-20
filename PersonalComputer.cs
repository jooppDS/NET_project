using System.ComponentModel.Design;

namespace task2;

class PersonalComputer : Device
{

    private const string manType = "P";
    private string OS = null;

    public PersonalComputer(long id, string name, bool active, string os) : base(id, name, active)
    {
        OS = os;
    }

    public PersonalComputer(long id, string name, bool active) : base(id, name, active) {
        
    }

    public bool PowerOn()
    {
        bool success = OS != null;
        if (!success)
        {
            throw new EmptySystemException();
        }
        
        _active = success;
        return success;
    }

    public void powerOff() {
        _active = false;
    }

    public string _os
    {
        get { return OS; }
        set { OS = value; }
    }
    
    public string getFileFormat() {
        return manType + ',' + base.getFileFormat() + _os;
    }

    public override string ToString()
    {
        return base.ToString() + "OS: " + _os + "\n";
    }
}