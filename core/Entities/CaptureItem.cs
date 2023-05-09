namespace MakoSystems.TicTac.Core;
public class CaptureItem : IFrameItem
{
    private int _id;
    private UniqueObjectType _uniqueObjectType;
    private static int _idCounter;
    private int _x, _y;

    public int Id => _id;
    public int X => _x;
    public int Y => _y;
    public UniqueObjectType UniqueObjectType
    { 
        get => _uniqueObjectType;
        set => _uniqueObjectType = value;
    }

    private CaptureItem(int x, int y, UniqueObjectType uniqueObjectType)
    {
        _x = x; _y = y;
        _idCounter++;
        _id = _idCounter;
        _uniqueObjectType = uniqueObjectType;
    }

    public static CaptureItem CreateEmptyItem(int x, int y)
    {
        return new CaptureItem(x,y, UniqueObjectType.E);
    }
}