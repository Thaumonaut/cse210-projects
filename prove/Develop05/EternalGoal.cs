public class EternalGoal : Goal
{
    public const int NAME_INDEX = 1;
    public const int DESCRIPTION_INDEX = 2;
    public const int POINTS_INDEX = 3;
    public const int TOTAL_COMPLETED_INDEX = 4;

    private int _timesCompleted;

    public EternalGoal(string name, string description, int points) : base(name, description, points){}

    public override int RecordEvent()
    {
        _timesCompleted++;
        return _points;
    }

    public override bool isComplete()
    {
        return false;
    }

    public override string CheckboxString()
    {
        return "[-]";
    }

    public override string StringifyData()
    {
        return $"EternalGoal|{_shortName}|{_description}|{_points}|{_timesCompleted}";
    }
}