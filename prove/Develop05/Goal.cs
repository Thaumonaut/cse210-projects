abstract public class Goal
{
    protected string _shortName;
    protected string _description;
    protected int _points;

    public Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    public abstract int RecordEvent();
    public abstract bool isComplete();
    public abstract string StringifyData();
    public virtual string CheckboxString()
    {
        if (isComplete())
        {
            return "[x]";
        }
        return "[ ]";
    }
    public virtual string GetDetailsString()
    {
        return $"{CheckboxString()} ~~ {_points}pt ~~ {_shortName} ({_description})";
    }
}