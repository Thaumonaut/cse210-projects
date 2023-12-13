using System.Text.Json.Serialization;

public class Task
{
    
    private string _title;
    private string _description;
    private Person _assignment;
    private DateTime _dueDate;
    private bool _isComplete;
    
    // private List<Task> _subTasks;
    // private bool _isSubtask;
    //private List<Content> _linkedContent;
    //private List<string> _workLog;
    //private double _workTime;

    public Task(string title, string description, Person person, string dueDate)
    {
        _title = title;
        _description = description;
        _assignment = person;
        _dueDate = DateTime.Parse(dueDate);

        // _linkedContent = new List<Content>();
        // _subTasks = new List<Task>();
        // _isSubtask = isSubtask;
        //_workLog = new List<string>();
        //_workTime = 0.0;
    }

    // ~~ PRIVATE METHODS ~~

    private string GetCheckboxString()
    {
        string checkboxString = "[ ]";
        if(_isComplete)
        {
            checkboxString = "[X]";
        }
        // if(!_isSubtask)
        // {
        //     checkboxString += $" [{GetSubTaskCompleteCount()}/{_subTasks.Count}]";
        // }

        return checkboxString;
    }

    // ~~ PUBLIC METHODS ~~

    // Add time worked based on start and end time.
    // Worklog entry to add notes about work done.
    
    // TODO: Create worklog class to handle workbook entries
    // public void AddLogEntry(string entry){_workLog.Add(entry);}
    // public void DisplayWorkLog(){}

    public string TaskToString(){return $"{GetCheckboxString()} Due: {_dueDate.ToLongDateString()} ({(_dueDate - DateTime.Now).Days} Days) | Assigned to: {_assignment.GetName()} | {_title} ({_description})";}
    public void ChangeAssignment(Person assignment){ _assignment = assignment;}

    // Linked Content Management
    // public void AddLinkedContent(Content content){_linkedContent.Add(content);}
    // public void RemoveLinkedContent(Content content){_linkedContent.Remove(content);}

    // Task Completion
    public void SetTaskComplete(){_isComplete = true;}
    public bool IsAllComplete()
    {
        // if(!_isComplete){return false;}
        // foreach (Task task in _subTasks)
        // {
        //     if (!task._isComplete)
        //     {
        //         return false;
        //     }
        // }

        // return true;

        return _isComplete;
    }

    // // Subtask Management
    // public void AddSubtask(Task subtask) {_subTasks.Add(subtask);}
    // public void DisplaySubTasks()
    // {
    //     foreach (Task task in _subTasks)
    //     {
    //         Console.Write("     ");
    //         Console.WriteLine(task.TaskToString());
    //     }
    // }
    // public void CompleteSubtask(int index)
    // {
    //     _subTasks[index].SetTaskComplete();
    // }
    // public int GetSubTaskCompleteCount()
    // {
    //     if(_subTasks.Count <= 0) {
    //         return 0;
    //     }
        
    //     int temp = 0;
    //     foreach (Task task in _subTasks)
    //     {
    //         if(task._isComplete)
    //         {
    //             temp++;
    //         }
    //     }
    //     return temp;
    // }


}