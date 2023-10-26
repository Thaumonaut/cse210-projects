using System;

class Program
{
    static void Main(string[] args)
    {
        Random rngGenerator = new Random();
        int randomNumber = rngGenerator.Next(1, 100);

        int maxAttempts = 10;
        int attempts = 0;

        bool isGuessed = false;

        while(attempts < maxAttempts && !isGuessed) {
            Console.Write("What is your guess? (1-100) ");
            int guess = int.Parse(Console.ReadLine());

            if(guess == randomNumber) {
                Console.WriteLine($"Congrats! You guessed the correct number in {attempts} attempts.");
                break;
            }

            Console.Clear();
            Console.WriteLine("==============================");
            Console.Write($"{guess} was incorrect. ");
            if(guess < randomNumber) {
                Console.WriteLine("The number is higher.");
            } else {
                Console.WriteLine("The number is lower.");
            }
            Console.WriteLine("==============================");

            attempts++;
        }
    }
}