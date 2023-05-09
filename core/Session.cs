namespace MakoSystems.TicTac.Core;

public class Session
{
    private readonly IFrame _frame;
    private readonly IFrameContextBuilder _frameContextBuilder;
    private readonly IRuleService _ruleService;
    public Session()
    {
        _frame = new Frame(3, 3);

        _frameContextBuilder = new FrameContextBuilder(_frame);
        _frameContextBuilder.Initialize();

        _ruleService = new RuleService(_frameContextBuilder);
    }

    public IFrame Frame => _frame;
    public IFrameContextBuilder FrameContextBuilder => _frameContextBuilder;
    public IRuleService RuleService => _ruleService;
}