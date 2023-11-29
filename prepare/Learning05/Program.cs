using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();

        Square s = new Square("Midori", 10);
        shapes.Add(s);
        Rectangle r = new Rectangle("Ao", 5, 12);
        shapes.Add(r);
        Circle c = new Circle("Aka", 4);
        shapes.Add(c);

        foreach (Shape shape in shapes)
        {
            string color = shape.GetColor();
            double area = shape.GetArea();

            Console.WriteLine($"This shape is {color} with an area of {area}");
        }
    }
}