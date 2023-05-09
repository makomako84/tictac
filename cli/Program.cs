using MakoSystems.TicTac.Core;

public class Program
{
    private static Session _session;
    public static void Main()
    {
        _session = new Session();
        TraverseLog();

        CaptureItemCommand captureItemCommand1 = new CaptureItemCommand(0, 0, CaptureObjectType.X);
        var response = (string)_session.RuleService.Capture(captureItemCommand1);
        Console.WriteLine(response);

        CaptureItemCommand captureItemCommand2 = new CaptureItemCommand(1, 0, CaptureObjectType.X);
        response = (string)_session.RuleService.Capture(captureItemCommand2);
        Console.WriteLine(response);

        CaptureItemCommand captureItemCommand3 = new CaptureItemCommand(1, 0, CaptureObjectType.O);
        response = (string)_session.RuleService.Capture(captureItemCommand3);
        Console.WriteLine(response);

        CaptureItemCommand captureItemCommand4 = new CaptureItemCommand(2, 0, CaptureObjectType.O);
        response = (string)_session.RuleService.Capture(captureItemCommand4);
        Console.WriteLine(response);

        //_session.FrameContextBuilder.Capture(0, 0, CaptureObjectType.X);
        //_session.FrameContextBuilder.Capture(1, 0, CaptureObjectType.X);
        //_session.FrameContextBuilder.Capture(2, 0, CaptureObjectType.O);
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
        Console.WriteLine();
    }
}




