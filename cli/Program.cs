using MakoSystems.TicTac.Core;

public class Program
{
    private static Session _session;
    public static void Main()
    {
        _session = new Session();
        TraverseLog();
        Check4();
    }
    private static void HandleTurn(bool response)
    {
        // (IHandler)InputController => (IHandler)TurnManagerService => (IHandler)CoreRule => (Class)TurnManagerService
        if (response)
        {
            ITurnFinishHandler finishHandler = (ITurnFinishHandler)_session.InputController;
            finishHandler.HandleFinishRequest(null);
        }
    }

    private static void Check4()
    {
        CaptureItemCommand captureItemCommand1 = new CaptureItemCommand(0, 2, CaptureObjectType.X);
        bool response = _session.InputController.Capture(captureItemCommand1);
        HandleTurn(response);
        TraverseLog();

        CaptureItemCommand captureItemCommand2 = new CaptureItemCommand(1, 1, CaptureObjectType.X);
        response = _session.InputController.Capture(captureItemCommand2);
        HandleTurn(response);
        TraverseLog();

        CaptureItemCommand captureItemCommand4 = new CaptureItemCommand(2, 0, CaptureObjectType.X);
        response = _session.InputController.Capture(captureItemCommand4);
        HandleTurn(response);
        TraverseLog();
    }

    private static void Check3()
    {
        CaptureItemCommand captureItemCommand1 = new CaptureItemCommand(0, 0, CaptureObjectType.O);
        var response = _session.InputController.Capture(captureItemCommand1);
        HandleTurn(response);
        TraverseLog();

        CaptureItemCommand captureItemCommand2 = new CaptureItemCommand(1, 1, CaptureObjectType.O);
        response = _session.InputController.Capture(captureItemCommand2);
        HandleTurn(response);
        TraverseLog();

        CaptureItemCommand captureItemCommand4 = new CaptureItemCommand(2, 2, CaptureObjectType.O);
        response = _session.InputController.Capture(captureItemCommand4);
        HandleTurn(response);
        TraverseLog();
    }

    private static void Check2()
    {
        CaptureItemCommand captureItemCommand1 = new CaptureItemCommand(0, 0, CaptureObjectType.O);
        var response = _session.InputController.Capture(captureItemCommand1);
        HandleTurn(response);
        TraverseLog();

        CaptureItemCommand captureItemCommand2 = new CaptureItemCommand(0, 1, CaptureObjectType.O);
        response = _session.InputController.Capture(captureItemCommand2);
        HandleTurn(response);
        TraverseLog();

        CaptureItemCommand captureItemCommand4 = new CaptureItemCommand(0, 2, CaptureObjectType.O);
        response = _session.InputController.Capture(captureItemCommand4);
        HandleTurn(response);
        TraverseLog();
    }
    private static void Check1()
    {
        CaptureItemCommand captureItemCommand1 = new CaptureItemCommand(0, 0, CaptureObjectType.X);
        var response = _session.InputController.Capture(captureItemCommand1);
        HandleTurn(response);
        TraverseLog();

        CaptureItemCommand captureItemCommand2 = new CaptureItemCommand(1, 0, CaptureObjectType.X);
        response = _session.InputController.Capture(captureItemCommand2);
        HandleTurn(response);
        TraverseLog();

        CaptureItemCommand captureItemCommand3 = new CaptureItemCommand(1, 0, CaptureObjectType.O);
        response = _session.InputController.Capture(captureItemCommand3);
        HandleTurn(response);
        TraverseLog();


        CaptureItemCommand captureItemCommand4 = new CaptureItemCommand(2, 0, CaptureObjectType.X);
        response = _session.InputController.Capture(captureItemCommand4);
        HandleTurn(response);
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




