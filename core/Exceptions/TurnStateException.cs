namespace MakoSystems.TicTac.Core;

public class TurnStateException : System.Exception
{
    public TurnStateException(string? message) : base(message)
    {
    }
}