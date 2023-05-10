using MakoSystems.TicTac.Host;
using MakoSystems.TicTac.Tests;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;

using var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        var config = context.Configuration;
        services.AddSingleton<ISessionPool, SessionPool>();
    })
    .Build();


var pool = host.Services.GetRequiredService<ISessionPool>();

var session1 = pool.GetNewSession();
var test1 = new CoreTests(session1);
test1.Check1();

var session2 = pool.GetNewSession();
var test2 = new CoreTests(session2);
test2.Check2();

