namespace MakoSystems.TicTac.Core;

public class Session
{
    private readonly IFrame _frame;
    private readonly IFrameContextBuilder _frameContextBuilder;
    private readonly IInputController _inputController;
    private readonly CoreRuleService _coreRuleService;
    private readonly TurnManagerService _turnManagerService;
    public Session()
    {
        _frame = new Frame(3, 3);

        _frameContextBuilder = new FrameContextBuilder(_frame);
        _frameContextBuilder.Initialize();

        _coreRuleService = new CoreRuleService(_frameContextBuilder);
        _turnManagerService = new TurnManagerService(_coreRuleService);

        _inputController = new InputController(_frameContextBuilder, _turnManagerService);
        
    }

    public IFrame Frame => _frame;
    public IFrameContextBuilder FrameContextBuilder => _frameContextBuilder;
    public IInputController InputController  => _inputController;
    public CoreRuleService CoreRuleService => _coreRuleService;
}