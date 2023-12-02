public class SimpleGoal : Goal
{
    public const int NAME_INDEX = 1;
    public const int DESCRIPTION_INDEX = 2;
    public const int POINTS_INDEX = 3;
    public const int COMPLETED_INDEX = 4;

    private bool _isComplete;

    public SimpleGoal(string name, string description, int points) : base(name, description, points)
    {
        _isComplete = false;
    }

    public SimpleGoal(string name, string description, int points, bool completion) : base(name, description, points)
    {
        _isComplete = completion;
    }

    public override int RecordEvent()
    {
        _isComplete = true;
        return _points;
    }

    public override bool isComplete()
    {
        return _isComplete;
    }

    public override string StringifyData()
    {
        return $"SimpleGoal|{_shortName}|{_description}|{_points}|{_isComplete}";
    }
}