using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();
        string name = PromptUserName();
        int favoriteNum = PromptUserNumber();
        int numSquared = SquareNumber(favoriteNum);
        DisplayResult(name, numSquared);
    }

    static void DisplayWelcome() {
        Console.WriteLine("Welcome to the Program!");
    }

    static string PromptUserName() {
        Console.Write("Please enter your name: ");
        return Console.ReadLine();
    }
    
    static int PromptUserNumber() {
        Console.Write("Please enter your favorite number: ");
        return int.Parse(Console.ReadLine());
    }

    static int SquareNumber(int a) {
        return a * a;
    }

    static void DisplayResult(string userName, int squaredNumber){
        Console.WriteLine($"{userName}, the square of your number is {squaredNumber}");
    }


}