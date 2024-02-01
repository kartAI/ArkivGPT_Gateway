using Microsoft.AspNetCore.Mvc;

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

        yield return element;
    }
    
}
