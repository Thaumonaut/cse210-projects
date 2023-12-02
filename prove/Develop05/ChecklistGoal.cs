public class ChecklistGoal : Goal
{
    public const int NAME_INDEX = 1;
    public const int DESCRIPTION_INDEX = 2;
    public const int POINTS_INDEX = 3;
    public const int TARGET_INDEX = 4;
    public const int BONUS_INDEX = 5;
    public const int TOTAL_COMPLETED_INDEX = 6;

    private int _timesCompleted;
    private int _targetAmount;
    private int _bonusPoints;

    public ChecklistGoal(string name, string description, int points, int target, int bonus) :base(name, description, points)
    {
        _timesCompleted = 0;
        _targetAmount = target;
        _bonusPoints = bonus;
    }

        public ChecklistGoal(string name, string description, int points, int target, int bonus, int completed) :base(name, description, points)
    {
        _timesCompleted = completed;
        _targetAmount = target;
        _bonusPoints = bonus;
    }

    public override int RecordEvent()
    {
        _timesCompleted++;
        if(isComplete())
        {
            return _points + _bonusPoints;
        }

        return _points;
    }

    public override bool isComplete()
    {
        return _timesCompleted > _targetAmount;
    }

    public override string GetDetailsString()
    {
        return $"{CheckboxString()} ~~ {_points}pt ~~ {_shortName} ({_description}) | Completed {_timesCompleted}/{_targetAmount}";
    }

    public override string StringifyData()
    {
        return $"ChecklistGoal|{_shortName}|{_description}|{_points}|{_targetAmount}|{_bonusPoints}|{_timesCompleted}";
    }
}
