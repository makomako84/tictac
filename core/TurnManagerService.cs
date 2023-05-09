using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MakoSystems.TicTac.Core;

public class TurnManagerService : ITurnService, InputFinishedObserver
{
    private int _notifyIndex;

    private TurnState _turnState;
    private CoreRuleService _ruleService;
    private List<InputFinishObservable> _observables;
    private int _currentTurn = 0;

    public TurnState TurnState => _turnState;
    public List<InputFinishObservable> Observables => _observables;
    public int NotifyCount => _observables.Count;
    public int CurrentTurn => _currentTurn;

    public TurnManagerService(CoreRuleService ruleService)
    {
        _observables = new List<InputFinishObservable>();
        _turnState = TurnState.Start;
        _ruleService = ruleService;
        _notifyIndex = 0;
    }

    public void Notify()
    {
        _notifyIndex++;
        if(_notifyIndex == NotifyCount)
        {
            _turnState = TurnState.End;
            _ruleService.OnTurnEnded();
        }
    }

    public void Subscribe(InputFinishObservable observable)
    {
        _observables.Add(observable);
    }

    public void Unsubscribe(InputFinishObservable observable)
    {
        _observables.Remove(observable);
    }

    public void NextTurn()
    {
        _notifyIndex = 0;
        _currentTurn++;
        _turnState = TurnState.Start;
    }
}
public interface InputFinishObservable
{
    public InputFinishedObserver Observer { get; }
}
public interface InputFinishedObserver
{
    public void Subscribe(InputFinishObservable observable);
    public void Unsubscribe(InputFinishObservable observable);
    public List<InputFinishObservable> Observables { get; }
    public void Notify();
    public int NotifyCount { get; }
}

public interface ITurnService
{
    public int CurrentTurn { get; }
    public void NextTurn();
}


public enum TurnState
{
    Start = 0,
    End = 1
}