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
            throw new FrameIndexException("Ошибка индексирования, деление на 0", e);
        }
        catch(Exception e)
        {
            Console.WriteLine("Log here");
        }

        return index;
    }
}