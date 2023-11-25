using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

public class Animation
{
    private List<string> _frames;
    private int _frameTime;

    public Animation(List<string> frames, int frameTime)
    {
        _frames = frames;
        _frameTime = frameTime;
    }

    /// <summary>
    /// Run console aniation for duration (in secs)
    /// </summary>
    /// <param name="duration"></param>
    public void RunAnimation(int duration)
    {
        DateTime end = DateTime.Now.AddSeconds(duration);
        int i = 0;

        while(DateTime.Now < end)
        {
            Console.Write(_frames[i++ % _frames.Count]);
            Thread.Sleep(_frameTime);
            ClearLine();
        }
    }

    public static void ClearLine()
    {
        Console.Write("\r");
        for (int j = 0; j < Console.BufferWidth; j++)
        {
            Console.Write(" ");
        }
        Console.Write('\r');

    }
}