using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        List<int> numbers = new List<int>();
        int lastnumber = -1;
        int sum = 0;
        int largest = 0;
        float average = 0.0f;



        // Get list of values
        while(true) {
            Console.Write("Enter a number: ");
            lastnumber = int.Parse(Console.ReadLine());
            
            if (lastnumber == 0) {
                break;
            }
            
            numbers.Add(lastnumber);
        }

        // Sum values and get largest
        foreach (int num in numbers) {
            sum += num;

            if (num > largest) {
                largest = num;
            }
        }

        average = sum / numbers.Count;

        Console.WriteLine("=========================================");
        Console.WriteLine($"The sum of all values is: {sum}");
        Console.WriteLine($"The average of all values is: {average}");
        Console.WriteLine($"The largest number is: {largest}");
        Console.WriteLine("=========================================");
    }
}