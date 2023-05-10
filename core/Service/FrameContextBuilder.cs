namespace MakoSystems.TicTac.Core;
public class FrameContextBuilder : IFrameContextBuilder
{
    private readonly IFrame _frame;
    private readonly IFramable _captureItems;

    public IFramable Frame => _frame;
    public IFramable CaptureItems => _captureItems;
    public FrameContextBuilder()
    {
        // а цифры через конфу передавать
        _frame = new Frame(3, 3);
        _captureItems = new CaptureItems(_frame.Width, _frame.Height);
    }

    public void Capture(CaptureItemCommand command)
    {
        var captureItem = (CaptureItem)_captureItems.Get(command.X, command.Y);
        captureItem.UniqueObjectType = (UniqueObjectType)command.CaptureObjectType;
    }

    public void Initialize()
    {
        for (int x = 0; x < _frame.Width; x++)
        {
            for (int y = 0; y < _frame.Height; y++)
            {
                var captureItem = CaptureItem.CreateEmptyItem(x, y);
                ((CaptureItems)_captureItems).InitializeItem(captureItem);

                _frame.Set(x, y, (int)captureItem.UniqueObjectType);
            }
        }
    }

    public UniqueObjectType Get(int x, int y)
    {
        
        var item = ((CaptureItem)_captureItems.Get(x, y)).UniqueObjectType;
        return item;
    }
}