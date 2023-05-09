using MakoSystems.TicTac.Core;

public class Program
{
    private static Session _session;
    public static void Main()
    {
        _session = new Session();
        TraverseLog();
        Check4();


        TraverseLog();
    }


    private static void Check4()
    {
        CaptureItemCommand captureItemCommand1 = new CaptureItemCommand(0, 2, CaptureObjectType.X);
        var response = (string)_session.InputController.Capture(captureItemCommand1);

        CaptureItemCommand captureItemCommand2 = new CaptureItemCommand(1, 1, CaptureObjectType.X);
        response = (string)_session.InputController.Capture(captureItemCommand2);

        CaptureItemCommand captureItemCommand4 = new CaptureItemCommand(2, 0, CaptureObjectType.X);
        response = (string)_session.InputController.Capture(captureItemCommand4);
    }

    private static void Check3()
    {
        CaptureItemCommand captureItemCommand1 = new CaptureItemCommand(0, 0, CaptureObjectType.O);
        var response = (string)_session.InputController.Capture(captureItemCommand1);

        CaptureItemCommand captureItemCommand2 = new CaptureItemCommand(1, 1, CaptureObjectType.O);
        response = (string)_session.InputController.Capture(captureItemCommand2);

        CaptureItemCommand captureItemCommand4 = new CaptureItemCommand(2, 2, CaptureObjectType.O);
        response = (string)_session.InputController.Capture(captureItemCommand4);
    }

    private static void Check2()
    {
        CaptureItemCommand captureItemCommand1 = new CaptureItemCommand(0, 0, CaptureObjectType.O);
        var response = (string)_session.InputController.Capture(captureItemCommand1);

        CaptureItemCommand captureItemCommand2 = new CaptureItemCommand(0, 1, CaptureObjectType.O);
        response = (string)_session.InputController.Capture(captureItemCommand2);

        CaptureItemCommand captureItemCommand4 = new CaptureItemCommand(0, 2, CaptureObjectType.O);
        response = (string)_session.InputController.Capture(captureItemCommand4);
    }
    private static void Check1()
    {
        CaptureItemCommand captureItemCommand1 = new CaptureItemCommand(0, 0, CaptureObjectType.X);
        var response = (string)_session.InputController.Capture(captureItemCommand1);

        CaptureItemCommand captureItemCommand2 = new CaptureItemCommand(1, 0, CaptureObjectType.X);
        response = (string)_session.InputController.Capture(captureItemCommand2);

        CaptureItemCommand captureItemCommand3 = new CaptureItemCommand(1, 0, CaptureObjectType.O);
        response = (string)_session.InputController.Capture(captureItemCommand3);


        CaptureItemCommand captureItemCommand4 = new CaptureItemCommand(2, 0, CaptureObjectType.X);
        response = (string)_session.InputController.Capture(captureItemCommand4);
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




