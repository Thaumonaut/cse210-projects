public class BreathingActivity : Activity
{
    public BreathingActivity() : base(
        name: "Breathing Activity", 
        description: "This activity will help you relax by walking your through breathing in and out slowly. We will be doing 4 4 4 breathing where you will breath in for 4 seconds, hold for 4 seconds, and breath out for 4 seconds. Clear your mind and focus on breathing."
    ){}

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