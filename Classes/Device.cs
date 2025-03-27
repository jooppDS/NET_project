using System.Linq.Expressions;

namespace task2;

public abstract class Device
{
    private string Id { set; get; }
    private string Name { set; get; }
    private bool Active;
    protected Device(string id, string name, bool active) {
        Id = id;
        Name = name;
        Active = active;
    }


    public string _name {
        get { return Name; }
        set { Name = value; }
    }

    public string _id
    {
        get { return Id; }
        set { Id = value; }
    }

    public bool _active
    {
        get { return Active; }
        set { Active = value; }
    }

    public virtual string getFileFormat() {
        return Name + ',' + Active;
    }

    public virtual bool PowerOff() {
        _active = false;
        return true;
    }

    public virtual bool PowerOn() {
        _active = true;
        return true;
    }
    
    public abstract bool Edit(Device otherDevice);
    
    public override string ToString() {
        return "ID: " + Id + "\nName: " + Name + "\nActive: " + Active + "\n";
    }
}