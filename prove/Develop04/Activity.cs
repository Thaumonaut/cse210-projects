public class Activity
{
    private string _name;
    private string _description;
    protected int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void DisplayStartMessage(){
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name} Activity\n");
        Console.WriteLine($"{_description}\n");
        Console.Write("How long, in seconds, would you like this session to last?: ");
        _duration = int.Parse(Console.ReadLine());
        Console.Clear();
        Console.WriteLine("Prepare yourself . . . ");
        ShowSpinner(5);
    }

    public void DisplayEndMessage(){
        Console.Clear();
        Console.WriteLine("Great job! You did really well with that activity.");
        ShowCheer(5);
    }
    public void ShowSpinner(int seconds){
        List<string> spinnerFrames = new List<string>()
        {
            "\\", "|", "/", "—"
        };

        Animation spinnerAnimation = new Animation(spinnerFrames, 100);
        spinnerAnimation.RunAnimation(seconds);
    }
    
    public void ShowCountDown(int seconds) {
        for (int i = seconds - 1; i >= 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            if(i > 10) {
                Console.Write("\b  \b");
            } else {
                Console.Write("\b \b");
            }
        }
    }

    public void ShowCheer(int seconds)
    {
        List<string> cheerFrames = new List<string>(){
            @"/(-_-)\",
            "-(>_<)-",
            @"\(^v^)/",
            "-(^_^)-",
        };
        Animation cheerAnimation = new Animation(cheerFrames, 300);
        cheerAnimation.RunAnimation(seconds);
    }
}