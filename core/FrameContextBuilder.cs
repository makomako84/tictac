namespace MakoSystems.TicTac.Core;
public class FrameContextBuilder : IFrameContextBuilder
{
    private readonly IFrame _frame;
    private readonly IFramable _captureItems;

    public IFramable CaptureItems => _captureItems;
    public FrameContextBuilder(IFrame frame)
    {
        _frame = frame;
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

public class CaptureItems : IFramable
{
    private readonly int _width;
    private readonly int _height;
    private readonly IFrameItem[] _captureItems;
    public CaptureItems(int width, int height)
    {
        _width = width;
        _height = height;
        _captureItems = (new CaptureItem[width * height]);
    }

    public void InitializeItem(CaptureItem captureItem)
    {
        _captureItems[this.GetIndex(captureItem.X, captureItem.Y)] = captureItem;
    }
    public int Width => _width;

    public int Height => _height;

    public IFrameItem Get(int x, int y)
    {
        return _captureItems[this.GetIndex(x, y)];
    }
}

public enum CaptureObjectType
{
    X = 0,
    O = 1
}
