namespace MakoSystems.TicTac.Core;

public class FrameIndexException : System.Exception
{
    public FrameIndexException(string? message) : base(message)
    {
    }

    public FrameIndexException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
