using MakoSystems.TicTac.Core;

public interface ITurnService
{
    public TurnState TurnState { get; }
    public int CurrentTurn { get; }
    public void NextTurn();
}