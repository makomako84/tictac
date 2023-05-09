using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MakoSystems.TicTac.Core;

public class TurnManagerService : ITurnService, ITurnFinishHandler
{
    private TurnState _turnState;
    private ITurnFinishHandler _ruleService;
    private int _currentTurn = 0;

    public TurnState TurnState => _turnState;
    public int CurrentTurn => _currentTurn;

    public TurnManagerService(CoreRuleService ruleService)
    {
        _turnState = TurnState.Start;
        _ruleService = ruleService;
    }

    public void NextTurn()
    {
        if(_turnState == TurnState.End)
        {
            Console.WriteLine("Turn finished");
            _currentTurn++;
            _turnState = TurnState.Start;
            Console.WriteLine($"Current turn: {_currentTurn}");
        }
        else
        {
            throw new TurnStateException("Try to start not finished turn");
        }
    }

    public void HandleFinishRequest(ITurnFinishHandler notifyer)
    {
        if(_turnState == TurnState.Start)
        {
            _turnState = TurnState.End;
            _ruleService.HandleFinishRequest(this);
        }
        else
        {
            throw new TurnStateException("Try to finish finished turn");
        }

    }
}

public class TurnStateException : System.Exception
{
    public TurnStateException(string? message) : base(message)
    {
    }
}


public interface ITurnService
{
    public TurnState TurnState { get; }
    public int CurrentTurn { get; }
    public void NextTurn();
}

public interface ITurnFinishHandler
{
    public void HandleFinishRequest(ITurnFinishHandler notifyer);
}


public enum TurnState
{
    Start = 0,
    End = 1
}