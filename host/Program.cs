using MakoSystems.TicTac.Host;
using MakoSystems.TicTac.Tests;
using MakoSystems.TicTac.Network;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;

using var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        var config = context.Configuration;
        services.Configure<ServerOptions>(config.GetSection(ServerOptions.Section));
        services.AddTransient<Server>();
        services.AddSingleton<ISessionPool, SessionPool>();
    })
    .Build();

#region run server

CancellationTokenSource cancellationTokenSource = new();
Console.CancelKeyPress += (sender, e) =>
{
    cancellationTokenSource.Cancel();
};
var service = host.Services.GetRequiredService<Server>();
await service.InitializeAsync();
await service.RunServerAsync(cancellationTokenSource.Token);
Console.ReadLine();

#endregion