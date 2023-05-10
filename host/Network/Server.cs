using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MakoSystems.TicTac.Network;

record ServerOptions
{
    public int Port { get; init; }
    public static string Section => "Server";
}

class Server
{
    private readonly int _port;
    private readonly ILogger _logger;

    public Server(IOptions<ServerOptions> options, ILogger<Server> logger)
    {
        _port = options.Value.Port;
        _logger = logger;
    }

    public async Task InitializeAsync(CancellationToken cancellationToken = default)
    { 

    }

    public async Task RunServerAsync(CancellationToken cancellationToken = default)
    {
        TcpListener listener = new(IPAddress.Any, _port);
        _logger.LogInformation("Quotes listener started on port {0}", _port);
        listener.Start();

        while (true)
        {
            cancellationToken.ThrowIfCancellationRequested();
            using TcpClient client = await listener.AcceptTcpClientAsync();
            _logger.LogInformation("Client connected with address and port: {0}", client.Client.RemoteEndPoint);
            var _ = SendAsync(client, cancellationToken);
        }
    }
    

    private async Task SendAsync(TcpClient client, CancellationToken cancellationToken = default)
    {
        client.LingerState = new LingerOption(true, 10);
        client.NoDelay = true;

        using NetworkStream stream = client.GetStream();

        Memory<byte> buffer = null;

        await stream.WriteAsync(buffer, cancellationToken);
    }
}




