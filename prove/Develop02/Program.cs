using System;
using System.Reflection.Metadata.Ecma335;

class Program
{
    static void Main(string[] args)
    {

        Journal myJournal = new Journal();
        bool isRunning = true;
        const string DefaultFilename = "journal.txt";

        List<string> prompts = new List<string>()
        {
            "What was something new you learned today?",
            "What is something you could do better tomorrow?",
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
        };

        string RandomPrompt() {
            int randomIndex = new Random().Next(0, prompts.Count);
            return prompts[randomIndex];
        }

        void CreateEntry()
        {
            Entry newEntry = new Entry();
            newEntry._prompt = RandomPrompt();
            Console.WriteLine(newEntry._prompt);
            newEntry._response = Console.ReadLine();
            newEntry._date = DateTime.Now.ToShortDateString();

            myJournal.entries.Add(newEntry);
        }

        string getFilename() {
            Console.WriteLine($"Enter filename: (Deault: {DefaultFilename})");
            string filename = Console.ReadLine();
            if (filename == "") {
                filename = DefaultFilename;
            }
            return filename;
        }

        while (isRunning) {
            
            Console.Clear();
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("(1) Create new entry.");
            Console.WriteLine("(2) View current enties.");
            Console.WriteLine("(3) [-filename] Save entries to disk.");
            Console.WriteLine("(4) [-filename] Load entries from disk.");
            Console.Write("('exit' / 'e' to close program): ");

            string selection = Console.ReadLine();
            string[] parsedSelection = selection.Split("-");
            string sanitziedSelection = parsedSelection[0].Trim().ToLower();
            string sanitziedMod = "";
            if(parsedSelection.Length > 1)
            {
                sanitziedMod = parsedSelection[1].Trim('\"');
            }

            Console.Clear();
            
            switch (sanitziedSelection)
            {
                case "1":
                    CreateEntry();
                    Console.WriteLine("New entry added!");
                    break;
                case "2":
                    myJournal.Display();
                    break;
                case "exit":
                case "e":
                    isRunning = false;
                    return;
                case "3":
                    if (sanitziedMod != "") {
                        Console.WriteLine($"Saved to \"{sanitziedMod}\"");
                        myJournal.SaveToFile(sanitziedMod);
                    } else {
                        string filename = getFilename();
                        Console.WriteLine($"Saved to \"{filename}\"");
                        myJournal.SaveToFile(filename);
                    }
                    break;
                case "4":
                    if (sanitziedMod != "") {
                        Console.WriteLine($"Loading: \"{sanitziedMod}\"");
                        myJournal.LoadFromFile(sanitziedMod);
                    } else {
                        string filename = getFilename();
                        Console.WriteLine($"Loading: \"{filename}\"");
                        myJournal.LoadFromFile(filename);
                    }
                    break;
                default:
                    Console.WriteLine("Sorry, that is not a valid response.");
                    break;
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}