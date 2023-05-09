using System.Security.Cryptography.X509Certificates;

namespace MakoSystems.TicTac.Core;

public abstract class Command
{
    public abstract void Execute();
}

public class CaptureItemCommand : Command
{
    private int _x;
    private int _y;
    private CaptureObjectType _captureObjectType;

    public int X => _x;
    public int Y => _y;
    public CaptureObjectType CaptureObjectType => _captureObjectType;
    public CaptureItemCommand(int x, int y, CaptureObjectType captureObjectType) 
    { 
        _x = x;
        _y = y;
        _captureObjectType = captureObjectType;
    }

    public override void Execute()
    {
        throw new NotImplementedException();
    }

    public override string ToString()
    {
        return $"Capture item at {_x},{_y} with {_captureObjectType}";
    }
}