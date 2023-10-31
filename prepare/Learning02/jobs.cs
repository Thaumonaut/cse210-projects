using System.Security.AccessControl;

public class Job {
    // According to Microsoft style guide, all public attributes should be in PascalCase. Only private instance fields should start with an (_) [https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/identifier-names?source=recommendations]
    public string Company;
    public string JobTitle;
    public int StartYear;
    public int EndYear;

    public void Display() {
        Console.WriteLine($"{JobTitle} ({Company}) {StartYear}-{EndYear}");
    }
}