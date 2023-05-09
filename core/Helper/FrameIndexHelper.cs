namespace MakoSystems.TicTac.Core;

internal static class FrameIndexHelper
{
    internal static int GetIndex(this IFramable framable, int x, int y)
    {
        int height = framable.Height;
        int width = framable.Width;

        
        int index = 0;
        try
        {
            index = (y % height) * width + x % width;
        }
        catch(System.DivideByZeroException e)
        {
            Console.WriteLine(e);
        }

        return index;
    }
}