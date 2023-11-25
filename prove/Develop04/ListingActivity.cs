public class ListingActivity : Activity
{
    private List<string> _prompts;
    private int _count;

    public ListingActivity() : base(name: "Listing Activity", description: "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.") {
        _prompts = new List<string>() {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?",
        };
    }

    public void Run(){
        DisplayStartMessage();
        Console.WriteLine($" ~~~~ {GetRandomPrompt()} ~~~~ ");
        Console.Write("Starting in . . . ");
        ShowCountDown(5);
        Console.WriteLine(" BEGIN!");

        int listCount = GetListFromUser().Count;
        Console.WriteLine($"Congrats, you were able to add {listCount} items to your list!");
        ShowLoadingDots(5);

        DisplayEndMessage();
    }
    public string GetRandomPrompt(){
        int randomIndex = new Random().Next(_prompts.Count);
        return _prompts[randomIndex];
    }
    public List<string> GetListFromUser(){
        List<string> userInput = new List<string>();
        DateTime timerEnd = DateTime.Now.AddSeconds(_duration);
        while(DateTime.Now < timerEnd)
        {
            Console.Write("> ");
            userInput.Add(Console.ReadLine());
        }

        return userInput;
    }
}