using System;
using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
    {
        string scriptureText = "And it came to pass that I, Nephi, said unto my father: I will go and do the things which the Lord hath commanded, for I know that the Lord giveth no commandments unto the children of men, save he shall prepare a way for them that they may accomplish the thing which he commandeth them.";
        Reference scriptureRef = new Reference("1 Nephi", 3, 7);
        Scripture testScripture = new Scripture(scriptureText, scriptureRef);

        // string displayText = testScripture.RenderScripture();
        // Console.Clear();
        // Console.WriteLine(displayText);
        // Console.ReadLine();

        while(!testScripture.IsAllHidden()) {
            Console.Clear();
            Console.WriteLine(testScripture.Display());
            Console.WriteLine();
            Console.WriteLine("Press Enter to continue");
            Console.WriteLine("Type \"last\" to restore previously last hidden words");
            Console.WriteLine("Type \"exit\" to close program");
            Console.Write("What would you like to do?: ");
            string response = Console.ReadLine();

            switch (response.ToLower())
            {
                case "e":
                case "exit":
                    return;
                case "last":
                    testScripture.RestoreLastHidden();
                    break;
                default:
                    testScripture.HideRandomWords(5);
                    break;
            }
        }

    }
}