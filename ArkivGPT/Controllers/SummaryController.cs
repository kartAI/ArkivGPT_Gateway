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
    public IActionResult Get([FromQuery] string GNR, [FromQuery] string BNR, [FromQuery] string SNR)
    {
        return Ok(new { GNR, BNR, SNR });
    }
    
}
