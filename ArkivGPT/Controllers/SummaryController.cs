using System.Text.Json;
using ArkivGPT_Gateway;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Mvc;

namespace ArkivGPT_Gateway.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class SummaryController : ControllerBase
{

    private readonly ILogger<SummaryController> _logger;

    public SummaryController(ILogger<SummaryController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public async Task Get([FromQuery] int gnr, [FromQuery] int bnr, [FromQuery] int snr)
    {
        var response = Response;
        response.Headers.Append("Content-Type", "text/event-stream");

        _logger.LogInformation("Creating new route to processor");
        // Use this to send the data were it is supposed to go
        var serverAddress = Environment.GetEnvironmentVariable("GRPC_SERVER_ADDRESS") ?? "http://localhost:5001"; // To handel docker and local
        using var channel = GrpcChannel.ForAddress(serverAddress);
        var client = new Summary.SummaryClient(channel);
        
        _logger.LogInformation("Getting reply from processor");

        try
        {
            var cancellationToken = new CancellationTokenSource(TimeSpan.FromSeconds(10));
            using var streamingCall = client.SaySummary(new SummaryRequest { Gnr = gnr, Bnr = bnr, Snr = snr });
            await foreach (var reply in streamingCall.ResponseStream.ReadAllAsync(
                               cancellationToken: cancellationToken.Token))
            {
                Console.WriteLine("Reply received from processor: " + reply);
                await response.WriteAsync($"data: {JsonSerializer.Serialize(reply)}\n\n");
            }

            Console.WriteLine("Stream completed.");
        }
        catch (RpcException ex) when (ex.StatusCode == Grpc.Core.StatusCode.Cancelled)
        {
            Console.WriteLine("Stream cancelled.");
        }
        
        await response.WriteAsync($"event: close\ndata: close\n\n");
    }
}
