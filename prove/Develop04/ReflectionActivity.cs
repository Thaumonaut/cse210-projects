public class RelfectionActivity : Activity
{

    List<string> _prompts;
    List<string> _questions;

    public RelfectionActivity() : base(name: "Reflection Activity", description: "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life."){
        _questions = new List<string>(){
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?",
        };

        _prompts = new List<string>(){
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless.",
        };
    }

    public void Run(){
        DisplayStartMessage();
        DisplayPrompt();
        Console.WriteLine("Ponder on the following questions as it relates to this experience.");
        Console.Write("Starting in . . . ");
        ShowCountDown(5);
        Console.WriteLine();

        DateTime timerEnd = DateTime.Now.AddSeconds(_duration);
        while(DateTime.Now < timerEnd)
        {
            DisplayQuestions();
        }

        DisplayEndMessage();

    }
    public string GetRandomPrompt(){
        int randomIndex = new Random().Next(_prompts.Count);
        return _prompts[randomIndex];
    }
    public string GetRandomQuestion(){
        int randomIndex = new Random().Next(_prompts.Count);
        return _questions[randomIndex];
    }
    public void DisplayPrompt(){
        Console.WriteLine("Think about the following prompt:");
        Console.WriteLine($" ~~~~ {GetRandomPrompt()} ~~~~ ");
        Console.WriteLine("\nWhen you have something ready, press enter to continue...");
        Console.ReadLine();
    }
    public void DisplayQuestions(){
        Console.Write($"> {GetRandomQuestion()}");
        ShowLoadingDots(5);
        Console.WriteLine();
    }
}