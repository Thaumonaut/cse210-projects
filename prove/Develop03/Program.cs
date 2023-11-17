using System;
using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
    {
        bool isRunning = true;
        
        string scriptureText = "And it came to pass that I, Nephi, said unto my father: I will go and do the things which the Lord hath commanded, for I know that the Lord giveth no commandments unto the children of men, save he shall prepare a way for them that they may accomplish the thing which he commandeth them.";
        Reference scriptureRef = new Reference("1 Nephi", 3, 7);
        Scripture testScripture = new Scripture(scriptureText, scriptureRef);

        Scripture scripture2 = new Scripture(
            @"For behold, this life is the time for men to prepare to meet God; yea, behold the day of this life is the day for men to perform their labors.
            And now, as I said unto you before, as ye have had so many witnesses, therefore, I beseech of you that ye do not procrastinate the day of your repentance until the end; for after this day of life, which is given us to prepare for eternity, behold, if we do not improve our time while in this life, then cometh the night of darkness wherein there can be no labor performed.
            Ye cannot say, when ye are brought to that awful crisis, that I will repent, that I will return to my God. Nay, ye cannot say this; for that same spirit which doth possess your bodies at the time that ye go out of this life, that same spirit will have power to possess your body in that eternal world.",

            new Reference("Alma", 34, 32, 34)    
        );

        Scripture currentScripture = scripture2;

        // string displayText = testScripture.RenderScripture();
        // Console.Clear();
        // Console.WriteLine(displayText);
        // Console.ReadLine();

        while (isRunning)
        {
            Console.Clear();
            Console.WriteLine(currentScripture.Display());
            Console.WriteLine();
            Console.WriteLine("Press Enter to continue");
            Console.WriteLine("Type \"last\" to restore previously last hidden words");
            Console.WriteLine("Type \"exit\" to close program");
            Console.Write("What would you like to do?: ");
            string response = Console.ReadLine();

            if (currentScripture.IsAllHidden())
            {
                isRunning = false;
            }

            switch (response.ToLower())
            {
                case "e":
                case "exit":
                    return;
                case "last":
                    currentScripture.RestoreLastHidden();
                    break;
                default:
                    currentScripture.HideRandomWords(5);
                    break;
            }
        }
    }
}