public class Resume {
    public string Name;
    public List<Job> Jobs = new List<Job>();

    public void Display() {
        Console.WriteLine("====================");
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine("====================");
        Console.WriteLine($"Experience:");

        foreach (var job in Jobs) {
            job.Display();
        }
        Console.WriteLine("====================");
    }

}