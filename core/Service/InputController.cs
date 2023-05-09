namespace MakoSystems.TicTac.Core;

public class InputController : IInputController, ITurnFinishHandler
{ 
    private readonly IFrameContextBuilder _frameContextBuilder;
    private readonly ITurnService _turnManagerService;
    public InputController(
        IFrameContextBuilder frameContextBuilder,
        ITurnService turnManagerService) 
    { 
        _frameContextBuilder = frameContextBuilder;
        _turnManagerService = turnManagerService;
    }

    public bool Capture(CaptureItemCommand captureItemCommand)
    {
        int x = captureItemCommand.X;
        int y = captureItemCommand.Y;
        UniqueObjectType itemType = _frameContextBuilder.Get(x, y);

        if(itemType == UniqueObjectType.E && 
            _turnManagerService.TurnState == TurnState.Start)
        {
            _frameContextBuilder.Capture(captureItemCommand);
            Console.WriteLine(captureItemCommand);
            return true;
        }
        else
        {
            // some handling here
            return false;
        }
    }

    public void HandleFinishRequest(ITurnFinishHandler notifyer)
    {
        ((ITurnFinishHandler)_turnManagerService).HandleFinishRequest(notifyer);
    }
}