namespace MakoSystems.TicTac.Core;

public class RuleService : IRuleService
{ 
    private readonly IFrameContextBuilder _frameContextBuilder;
    public RuleService(IFrameContextBuilder frameContextBuilder) 
    { 
        _frameContextBuilder = frameContextBuilder;
    }

    public object Capture(CaptureItemCommand captureItemCommand)
    {
        UniqueObjectType itemType = _frameContextBuilder.Get(captureItemCommand.X, 
            captureItemCommand.Y);
        if(itemType == UniqueObjectType.E)
        {
            _frameContextBuilder.Capture(captureItemCommand);
            return "Success";
        }
        else
        {
            // some handling here
            return "Error, попытка занять занятую клетку";
        }
    }
}