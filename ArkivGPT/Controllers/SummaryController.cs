using Microsoft.AspNetCore.Mvc;
using Grpc.Net.Client;

namespace ArkivGPT.Controllers;

[ApiController]
[Route("[controller]")]
public class SummaryController : ControllerBase
{

    private readonly ILogger<SummaryController> _logger;

    public SummaryController(ILogger<SummaryController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public async IAsyncEnumerable<SummaryElement> Get([FromQuery] int gnr, [FromQuery] int bnr, [FromQuery] int snr)
    {
        var element = new SummaryElement(new DateOnly(2020, 5, 2), "Test resolution 1", "http://test1");

        // Use this to send the data were it is supposed to go
        var serverAddress = Environment.GetEnvironmentVariable("GRPC_SERVER_ADDRESS") ?? "http://localhost:5001"; // To handel docker and local
        using var channel = GrpcChannel.ForAddress(serverAddress);
        var client = new Greeter.GreeterClient(channel);
        var reply = await client.SayHelloAsync(new HelloRequest { Name = "GreeterClient123" });
        Console.WriteLine("Greeting: " + reply.Message);

        yield return element;
    }
    
}
