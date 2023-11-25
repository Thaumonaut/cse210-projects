using System;

class Program
{
    static void Main(string[] args)
    {
        // List<string> animationSteps = new List<string>(){".", "o", "O", "o"};

        Menu();

    }

    static void Menu()
    {
        Console.Clear();
        Console.WriteLine("Select an Activity: ");
        Console.WriteLine("1. Breathing Activity");
        Console.WriteLine("Exit / E: Close the program");
        Console.WriteLine();
        Console.Write("Select Activity: ");

        string selection = Console.ReadLine();

        switch (selection)
        {
            case "1":
                new BreathingActivity("Breathing", "Time to destress with some simple breathing exersizes. We will be doing 4 4 4 breathing where you will breath in for 4 seconds, hold for 4 seconds, and breath out for 4 seconds. This should help bring down your anxiety levels and help you to focus!").Run();
                break;
            default:
                break;
        }

    }
}