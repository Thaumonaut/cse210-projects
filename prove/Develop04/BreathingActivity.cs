public class BreathingActivity : Activity
{
    public BreathingActivity(string name, string description) 
    : base(name, description){}
    public void Run(){
        DisplayStartMessage();
        Console.Clear();
        Console.WriteLine("Let's Begin!");
        Thread.Sleep(500);
        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while(DateTime.Now < endTime)
        {
            Console.Write("Breath In: ");
            ShowCountDown(4);
            Animation.ClearLine();
            Console.Write("Hold: ");
            ShowCountDown(4);
            Animation.ClearLine();
            Console.Write("Breath Out: ");
            ShowCountDown(4);
            Animation.ClearLine();
        }

        DisplayEndMessage();
    }
}