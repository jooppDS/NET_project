using System.Linq.Expressions;

namespace task2;

public abstract class Device
{
    private long Id { set; get; }
    private string Name { set; get; }
    private bool Active;
    protected Device(long id, string name, bool active) {
        Id = id;
        Name = name;
        Active = active;
    }


    public string _name {
        get { return Name; }
        set { Name = value; }
    }

    public long _id
    {
        get { return Id; }
        set { Id = value; }
    }

    public bool _active
    {
        get { return Active; }
        set { Active = value; }
    }

    public string getFileFormat() {
        return Name + ',' + Active + ',';
    }

    public override string ToString() {
        return "ID: " + Id + "\nName: " + Name + "\nActive: " + Active + "\n";
    }
}