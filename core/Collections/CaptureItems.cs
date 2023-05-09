namespace MakoSystems.TicTac.Core;

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
