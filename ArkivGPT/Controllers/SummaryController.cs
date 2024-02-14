using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Grpc.Net.Client;

namespace ArkivGPT.Controllers;

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
        Console.Write("Accessed");
        var element = new SummaryElement(new DateOnly(2020, 5, 2), "Test resolution 1", "http://test1");
        
        var response = Response;
        response.Headers.Add("Content-Type", "text/event-stream");

        for (var i = 0; i < 10; i++)
        {
            await response.WriteAsync($"data: {JsonSerializer.Serialize(element)}\n\n");
            await response.Body.FlushAsync();
            await Task.Delay(1000);
        }
    }
    
}
