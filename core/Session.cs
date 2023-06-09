using Microsoft.Extensions.DependencyInjection;

namespace MakoSystems.TicTac.Core;

public class Session
{
    private readonly Guid _sessionId;
    private readonly Guid _clientId;
    private readonly ServiceProvider _container;

    public Guid SessionId => _sessionId;
    public Guid ClientId => _clientId;
    public Session(Guid clientId)
    {
        _clientId = clientId;
        _sessionId = Guid.NewGuid();

        Console.WriteLine($"New session inited, {_sessionId}");

        _container = GetServiceProvider();
        var contextBuilder = _container.GetRequiredService<IFrameContextBuilder>();
        contextBuilder.Initialize();
    }

    private ServiceProvider GetServiceProvider()
    {
        ServiceCollection services = new();
        services.AddSingleton<IFrameContextBuilder, FrameContextBuilder>();
        services.AddSingleton<CoreRuleService>();
        services.AddSingleton<ITurnService, TurnManagerService>();
        services.AddSingleton<IInputController, InputController>();
        return services.BuildServiceProvider();
    }

    //public IFrame Frame => _frame;
    public IFrameContextBuilder FrameContextBuilder => _container.GetRequiredService<IFrameContextBuilder>();
    public IInputController InputController => _container.GetRequiredService<IInputController>();
    public CoreRuleService CoreRuleService => _container.GetRequiredService<CoreRuleService>();
}