using System.Text.Json;
using ArkivGPT_Gateway;
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
        // Use this to send the data were it is supposed to go
        var serverAddress = Environment.GetEnvironmentVariable("GRPC_SERVER_ADDRESS") ?? "http://localhost:5001"; // To handel docker and local
        using var channel = GrpcChannel.ForAddress(serverAddress);
        var client = new Summary.SummaryClient(channel);
        var reply = await client.SaySummaryAsync(new SummaryRequest { Gnr = "1" });
        Console.WriteLine("Greeting: " + reply.Resolution);
        
        var response = Response;
        response.Headers.Append("Content-Type", "text/event-stream");
        
        await response.WriteAsync($"data: {JsonSerializer.Serialize(reply)}\n\n");
        await response.Body.FlushAsync();

    }
    
}
