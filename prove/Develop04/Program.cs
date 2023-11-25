using System;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        Menu();
    }

    static void Menu()
    {
        while (true)
        {    
            Console.Clear();
            Console.WriteLine("Select an Activity: ");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4: Close the program");
            Console.WriteLine();
            Console.Write("Enter Selection: ");

            string selection = Console.ReadLine();

            switch (selection)
            {
                case "1":
                    new BreathingActivity().Run();
                    break;
                case "2":
                    new RelfectionActivity().Run();
                    break;
                case "3":
                    new ListingActivity().Run();
                    break;
                default:
                    return;
            }
        }

    }
}