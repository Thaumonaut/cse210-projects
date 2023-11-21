using System;

class Program
{
    static void Main(string[] args)
    {
        MathAssignment assignment1 = new MathAssignment("Jacob", "Fractions", "1.5", "2-4, 6, 9-11");

        Console.Clear();
        Console.WriteLine(assignment1.GetSummary());
        Console.WriteLine(assignment1.GetHomeworkList());

        Console.WriteLine();

        WritingAssignment assignment2 = new WritingAssignment("Jacob", "Creative Writing", "A Day on Mars");

        Console.WriteLine(assignment2.GetSummary());
        Console.WriteLine(assignment2.GetWritingInformation());
    }
}