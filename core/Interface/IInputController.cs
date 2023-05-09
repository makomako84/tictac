namespace MakoSystems.TicTac.Core;

public interface IInputController
{
    public object Capture(CaptureItemCommand captureItemCommand);
}