namespace MakoSystems.TicTac.Core;

public interface IInputController
{
    public bool Capture(CaptureItemCommand captureItemCommand);
}