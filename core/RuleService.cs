namespace MakoSystems.TicTac.Core;

public class RuleService : IRuleService
{ 
    private readonly IFrameContextBuilder _frameContextBuilder;
    private readonly IFrame _frame;
    public RuleService(
        IFrameContextBuilder frameContextBuilder,
        IFrame frame) 
    { 
        _frameContextBuilder = frameContextBuilder;
        _frame = frame;
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

    private void CheckWinningState()
    {
        var captureItems =_frameContextBuilder.CaptureItems;
        for(int y=0; y< _frame.Height; y++)
        {
            bool winningState = false;
            for(int x = 0; x< _frame.Width; x++)
            {
                
            }
        }
    }
}