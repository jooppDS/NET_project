using System.ComponentModel.Design;

namespace task2;

class PersonalComputer : Device
{

    private const string manType = "P";
    private string OS = null;

    public PersonalComputer(string id, string name, bool active, string os) : base(id, name, active)
    {
        OS = os;
    }

    public PersonalComputer(string id, string name, bool active) : base(id, name, active) {
        
    }

    public override bool PowerOn()
    {
        bool success = OS != null;
        if (!success)
        {
            throw new EmptySystemException();
        }
        
        _active = success;
        return success;
    }

    public override bool Edit(Device otherDevice)
    {
        if (otherDevice is not PersonalComputer newComputer)
            throw new ArgumentException();

        _id = newComputer._id;
        _name = newComputer._name;
        _active = newComputer._active;
        _os = newComputer._os;


        return true;
    }


    public string _os
    {
        get { return OS; }
        set { OS = value; }
    }
    
    public override string getFileFormat() {
        if(_os == null)
            return  manType + ',' + base.getFileFormat();
        return manType + ',' + base.getFileFormat() +',' +_os;
    }

    public override string ToString()
    {
        return base.ToString() + "OS: " + _os + "\n";
    }
}