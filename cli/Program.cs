using MakoSystems.TicTac.Core;

public class Program
{
    private static Session _session;
    public static void Main()
    {
        _session = new Session();
        TraverseLog();

        _session.FrameContextBuilder.Capture(0, 0, UniqueObjectType.X);
        _session.FrameContextBuilder.Capture(1, 0, UniqueObjectType.X);
        _session.FrameContextBuilder.Capture(2, 0, UniqueObjectType.O);
        TraverseLog();
    }

    private static void TraverseLog()
    {
        for (int y = 0; y < _session.Frame.Height; y++)
        {
            for (int x = 0; x < _session.Frame.Height; x++)
            {
                var frameItem = _session.FrameContextBuilder.Get(x, y);
                System.Console.Write(frameItem.ToString() + " ");
            }
            Console.WriteLine();
        }
    }
}




