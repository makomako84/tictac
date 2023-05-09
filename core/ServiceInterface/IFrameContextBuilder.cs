namespace MakoSystems.TicTac.Core;

/*
 * IFrameContextBuilder просто строит
 * Ему не важны детали валидации, он просто размещает элементы
 */
public interface IFrameContextBuilder
{
    public void Capture(CaptureItemCommand captureCommand);
    public UniqueObjectType Get(int x, int y);
    public void Initialize();
    public IFramable CaptureItems { get; }
}