using System.Collections;

namespace MakoSystems.TicTac.Core;

public interface IFrame
{
    public int Width { get; }
    public int Height { get; }
    public FrameItem2[] Frames { get; }
    internal void Set(int x, int y, int objectId);
    internal void Set(int x, int y, int width, int height, int objectId);
    internal void Free(int x, int y);
    internal void Free(int x, int y, int width, int height);
    public FrameItem2 Get(int x, int y);
    internal void Intialize();
    [Obsolete]
    internal void Initialize(IEnumerable source);
}