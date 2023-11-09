public class Fraction {
    private int _top;
    private int _bottom;
    
    // Constructors
    public Fraction() 
    {
        _top = 1;
        _bottom = 1;
    }

    public Fraction(int number) 
    {
        _top = number;
        _bottom = 1;
    }
    
    public Fraction(int top, int bottom) 
    {
        _top = top;
        _bottom = bottom;
    }

    // Getter / Setters
    public int GetTop()
    {
        return _top;
    }

    public int GetBottom()
    {
        return _bottom;
    }

    public void SetTop(int top)
    {
        _top = top;
    }

    public void SetBottom(int bottom)
    {
        _bottom = bottom;
    }

    // Methods

    public string GetFractionString()
    {
        return $"{_top}/{_bottom}";
    }

    public double GetDecimalValue()
    {
        return (double)_top / (double)_bottom;
    }

}