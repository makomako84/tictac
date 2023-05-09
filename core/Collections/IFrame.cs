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