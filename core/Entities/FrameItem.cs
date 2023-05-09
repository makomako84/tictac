using MakoSystems.TicTac.Core;

public struct FrameItem : IFrameItem
{
    private int _x;
    private int _y;
    private int _objectId;
    public FrameItem(int x, int y)
    {
        _x = x;
        _y = y;
        _objectId = -1;
    }
    public int X { get => _x; }
    public int Y { get => _y; }
    public int ObjectId
    {
        get => _objectId;
        set => _objectId = value;
    }

    public override string ToString() =>
        $"({_x},{_y}):{_objectId}";
}