namespace MakoSystems.TicTac.Core;

public interface IFramable
{
    public int Width { get; }
    public int Height { get; }
    public IFrameItem Get(int x, int y);
}