namespace MakoSystems.TicTac.Core;


public interface ITurnFinishHandler
{
    public void HandleFinishRequest(ITurnFinishHandler notifyer);
}