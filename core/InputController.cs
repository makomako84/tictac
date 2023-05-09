namespace MakoSystems.TicTac.Core;

public class InputController : IInputController, InputFinishObservable
{ 
    private readonly IFrameContextBuilder _frameContextBuilder;
    private readonly TurnManagerService _turnManagerService;
    public InputController(
        IFrameContextBuilder frameContextBuilder,
        TurnManagerService turnManagerService) 
    { 
        _frameContextBuilder = frameContextBuilder;
        _turnManagerService = turnManagerService;
    }

    public InputFinishedObserver Observer => _turnManagerService;

    public object Capture(CaptureItemCommand captureItemCommand)
    {
        UniqueObjectType itemType = _frameContextBuilder.Get(captureItemCommand.X, 
            captureItemCommand.Y);
        if(itemType == UniqueObjectType.E && 
            _turnManagerService.TurnState == TurnState.Start)
        {
            _frameContextBuilder.Capture(captureItemCommand);
            InputFinished();
            return "Success";
        }
        else
        {
            // some handling here
            return "Error, попытка занять занятую клетку";
        }
    }

    private void InputFinished() => Observer.Notify();
}