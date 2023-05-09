using System.Collections;

namespace MakoSystems.TicTac.Core;

public interface IFrame : IFramable
{
    public FrameItem[] Frames { get; }
    internal void Set(int x, int y, int objectId);
    internal void Set(int x, int y, int width, int height, int objectId);
    internal void Free(int x, int y);
    internal void Free(int x, int y, int width, int height);
    
    internal void Intialize();
    [Obsolete]
    internal void Initialize(IEnumerable source);
}

public interface IFramable
{
    public int Width { get; }
    public int Height { get; }
    public IFrameItem Get(int x, int y);
}

public interface IFrameItem
{
    public int X { get; }
    public int Y { get; }
}