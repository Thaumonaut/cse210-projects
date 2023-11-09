using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction defaultFraction = new Fraction();
        Console.WriteLine(defaultFraction.GetFractionString());
        Console.WriteLine(defaultFraction.GetDecimalValue());

        Fraction wholeNumberFraction = new Fraction(5);
        Console.WriteLine(wholeNumberFraction.GetFractionString());
        Console.WriteLine(wholeNumberFraction.GetDecimalValue());

        Fraction threeQuarter = new Fraction(3, 4);
        Console.WriteLine(threeQuarter.GetFractionString());
        Console.WriteLine(threeQuarter.GetDecimalValue());

        Fraction third = new Fraction(1, 3);
        Console.WriteLine(third.GetFractionString());
        Console.WriteLine(third.GetDecimalValue());
    }
}