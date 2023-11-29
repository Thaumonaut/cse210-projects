public class Rectangle : Shape
{
    private double _height;
    private double _width;

    public Rectangle(string color, double height, double width) : base(color)
    {
        _height = height;
        _width = width;
    }

    public override double GetArea()
    {
        return _height * _width;
    }
}