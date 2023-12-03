using System.Reflection;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    private int _level;
    private int _points_till_next_levelUp;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
        _points_till_next_levelUp = 100;
        _level = 0;
    }

    public void Start()
    {
        while (true)
        {
            Console.WriteLine($"Welcome to Goaltify.");
            ShowPlayerInfo();

            Console.WriteLine("1. Create Goal");
            Console.WriteLine("2. Record Event");
            Console.WriteLine("3. Display Goals");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Load Goals");
            Console.WriteLine("6. Exit Program");
            Console.WriteLine();

            Console.Write("> ");

            int selection = int.Parse(Console.ReadLine());
            Console.Clear();

            switch (selection)
            {
                case 1:
                    CreateGoal();
                    break;
                case 2:
                    RecordEvent();
                    break;
                case 3:
                    ListGoals();
                    break;
                case 4:
                    SaveGoals();
                    break;
                case 5:
                    LoadGoals();
                    break;
                case 6:
                default:
                    return;
            }
        }
    }
    public void CreateGoal()
    {
        Console.WriteLine("Please select a goal.");
        Console.WriteLine("1. Simple Goal (A Single task to complete)");
        Console.WriteLine("2. Eternal Goal (A goal that never ends)");
        Console.WriteLine("3. Checklist Goal (Something you want to accomplish a certain number of times)");
        Console.WriteLine();
        Console.Write("> ");

        int selection = int.Parse(Console.ReadLine());
        Console.Clear();

        switch (selection)
        {
            case 1:
                CreateSimpleGoal();
                break;
            case 2:
                CreateEternalGoal();
                break;
            case 3:
                CreateChecklistGoal();
                break;
            default:
                Console.WriteLine("Sorry, that is not an option. Returning to Main Menu ");
                LoadingAnimation(2);
                break;
        }

        Console.Clear();
    }
    public void RecordEvent()
    {
        if(_goals.Count == 0)
        {
            Console.WriteLine("No Goals created yet. Please create a goal first ");
            LoadingAnimation(2);
            return;
        }

        Console.WriteLine("Which goal would you like to record?");
        ListGoals();

        Console.Write("> ");
        int selection = int.Parse(Console.ReadLine());

        _score += _goals[selection - 1].RecordEvent();

        if (_score >= _points_till_next_levelUp) {
            _level++;
            _points_till_next_levelUp += 100;
            Console.WriteLine("CONGRATS! You have leveled up!");
        }

        Console.Clear();
        Console.WriteLine("Goal Updated!");
        ShowPlayerInfo();
        LoadingAnimation(3);
    }
    public void ListGoals()
    {
        if(_goals.Count == 0)
        {
            Console.WriteLine("No Goals created yet. Please create a goal first ");
            LoadingAnimation(2);
            return;
        }

        int index = 1;
        foreach (Goal goal in _goals)
        {
            Console.WriteLine($"{index++}. {goal.GetDetailsString()}");
        }
        Console.WriteLine();
    }
    public void SaveGoals()
    {
        if(_goals.Count == 0)
        {
            Console.Write("No Goals created yet. Please create a goal first ");
            LoadingAnimation(2);
            return;
        }

        Console.WriteLine("enter a filename to save to");
        Console.Write("> ");

        string filename = Console.ReadLine();
        Console.WriteLine("Saving Data, please wait ");
        LoadingAnimation(2);


        using (StreamWriter outputfile = new StreamWriter(filename))
        {
            outputfile.WriteLine($"score|{_score}");
            foreach (Goal goal in _goals)
            {
                outputfile.WriteLine(goal.StringifyData());
            }
        }
    }
    public void LoadGoals()
    {
        _goals.Clear();

        Console.WriteLine("What file would you like to load?");
        Console.Write("> ");

        string filename = Console.ReadLine();
        string[] lines;
        try
        {
            lines = File.ReadAllLines(filename);
        }
        catch (System.Exception)
        {
            Console.WriteLine("That file does not exist, exiting back to main manu.");
            return;
        }

        foreach (string line in lines)
        {
            string[] data = line.Split("|");

            switch (data[0])
            {
                case "SimpleGoal":
                    string simpleName = data[SimpleGoal.NAME_INDEX];
                    string simpleDescription = data[SimpleGoal.DESCRIPTION_INDEX];
                    int simplePoints = int.Parse(data[SimpleGoal.POINTS_INDEX]);
                    bool isComplete = bool.Parse(data[SimpleGoal.COMPLETED_INDEX]);
                    _goals.Add(new SimpleGoal(name: simpleName, description: simpleDescription, points: simplePoints, completion: isComplete));
                    break;
                case "EternalGoal":
                    string eternalName = data[EternalGoal.NAME_INDEX];
                    string eternalDescription = data[EternalGoal.DESCRIPTION_INDEX];
                    int eternalPoints = int.Parse(data[EternalGoal.POINTS_INDEX]);
                    _goals.Add(new EternalGoal(name: eternalName, description: eternalDescription, points: eternalPoints));
                    break;
                case "ChecklistGoal":
                    string checklistName = data[ChecklistGoal.NAME_INDEX];
                    string checklistDescription = data[ChecklistGoal.DESCRIPTION_INDEX];
                    int checklistPoints = int.Parse(data[ChecklistGoal.POINTS_INDEX]);
                    int checklistBonus = int.Parse(data[ChecklistGoal.BONUS_INDEX]);
                    int checklistGoal = int.Parse(data[ChecklistGoal.TARGET_INDEX]);
                    int checklistAmount = int.Parse(data[ChecklistGoal.TOTAL_COMPLETED_INDEX]);
                    _goals.Add(new ChecklistGoal(name: checklistName, description: checklistDescription, points: checklistPoints, target: checklistGoal, bonus: checklistBonus, completed: checklistAmount));
                    break;
                case "score":
                    _score = int.Parse(data[1]);
                    break;
                default:
                    break;
            }
        }
    }

    public void ShowPlayerInfo()
    {
        Console.WriteLine($"Your current score is {_score} points!");
        Console.WriteLine($"Your current level is {_level}! (You are {_points_till_next_levelUp - _score} points away from your next level.)");
        Console.WriteLine();
    }

    public void LoadingAnimation(int seconds)
    {
        int interval = 500;
        DateTime timerEnd = DateTime.Now.AddSeconds(seconds);
        while(DateTime.Now < timerEnd)
        {           
            Console.Write(".");
            Thread.Sleep(interval);
            Console.Write(".");
            Thread.Sleep(interval);
            Console.Write(".");
            Thread.Sleep(interval);
            Console.Write("\b\b\b   \b\b\b");
            Thread.Sleep(interval);
        }
    }

    private void CreateSimpleGoal()
    {
        Console.WriteLine("Creating Simple Goal...");
        Console.Write("What is the name of this goal?: ");
        string name = Console.ReadLine();
        Console.Write("Give a short description of this goal: ");
        string description = Console.ReadLine();
        Console.Write("How many points is this worth?: ");
        int points = int.Parse(Console.ReadLine());

        SimpleGoal goal = new SimpleGoal(name, description, points);
        _goals.Add(goal);

        Console.WriteLine("Goal Created!");
        Console.WriteLine(goal.GetDetailsString());
        Console.Write("Returning to main menu ");
        LoadingAnimation(2);
    }
    private void CreateEternalGoal()
    {
        Console.WriteLine("Creating Eternal Goal...");
        Console.Write("What is the name of this goal?: ");
        string name = Console.ReadLine();
        Console.Write("Give a short description of this goal: ");
        string description = Console.ReadLine();
        Console.Write("How many points is this worth?: ");
        int points = int.Parse(Console.ReadLine());

        EternalGoal goal = new EternalGoal(name, description, points);
        _goals.Add(goal);

        Console.WriteLine("Goal Created!");
        Console.WriteLine(goal.GetDetailsString());
        Console.Write("Returning to main menu ");
        LoadingAnimation(2);
    }
    private void CreateChecklistGoal()
    {
        Console.WriteLine("Creating Checklist Goal...");
        Console.Write("What is the name of this goal?: ");
        string name = Console.ReadLine();
        Console.Write("Give a short description of this goal: ");
        string description = Console.ReadLine();
        Console.Write("How many points is this worth for each completion?: ");
        int points = int.Parse(Console.ReadLine());
        Console.Write("How many times do you want to complete this goal for a bonus?: ");
        int target = int.Parse(Console.ReadLine());
        Console.Write("How many bonus points is it worth?: ");
        int bonus = int.Parse(Console.ReadLine());

        ChecklistGoal goal = new ChecklistGoal(name, description, points, target, bonus);
        _goals.Add(goal);

        Console.WriteLine("Goal Created!");
        Console.WriteLine(goal.GetDetailsString());
        Console.Write("Returning to main menu ");
        LoadingAnimation(2);
    }
}