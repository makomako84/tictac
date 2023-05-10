using MakoSystems.TicTac.Core;

namespace MakoSystems.TicTac.Tests;

public class CoreTests
{
    private Session _session;

    public CoreTests(Session session)
    {
        _session = session;
    }

    public void Check4()
    {
        Console.WriteLine("===Diagonal 2 check===");
        TraverseLog();

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

    public void Check3()
    {
        Console.WriteLine("===Diagonal 1 check===");
        TraverseLog();

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

    public void Check2()
    {
        Console.WriteLine("===Vertical check===");
        TraverseLog();

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
    public void Check1()
    {
        Console.WriteLine("===Horizontal check===");
        TraverseLog();

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

    private void HandleTurn(bool response)
    {
        // (IHandler)InputController => (IHandler)TurnManagerService => (IHandler)CoreRule => (Class)TurnManagerService
        if (response)
        {
            ITurnFinishHandler finishHandler = (ITurnFinishHandler)_session.InputController;
            finishHandler.HandleFinishRequest(null);
        }
    }

    private void TraverseLog()
    {
        for (int y = 0; y < _session.FrameContextBuilder.Frame.Height; y++)
        {
            for (int x = 0; x < _session.FrameContextBuilder.Frame.Height; x++)
            {
                var frameItem = _session.FrameContextBuilder.Get(x, y);
                System.Console.Write(frameItem.ToString() + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}




