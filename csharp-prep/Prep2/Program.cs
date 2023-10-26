using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        int grade = int.Parse(Console.ReadLine());

        string letter = "F";
        string sign = "";

        if(!(grade > 100 || grade < 60)) {
            int gradeEnding = grade % 10;
            if(gradeEnding >= 7) {
                sign = "+";
            } else if (gradeEnding < 3) {
                sign = "-";
            }
        }

        if (grade >= 90) {
            letter = ("A");
        } else if (grade >= 80) {
            letter = ("B");
        } else if (grade >= 70) {
            letter = ("C");
        } else if (grade >= 60) {
            letter = ("D");
        } else if (grade < 60) {
            letter = ("F");
        }

        Console.WriteLine($"Your grade is: {letter}{sign}");
        if (grade >= 70) {
            Console.WriteLine("You passed the class!");
        } else {
            Console.WriteLine("Better try harder next time!");
        }
    }
}