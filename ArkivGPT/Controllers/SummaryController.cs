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
    public ActionResult<Summary> Get([FromQuery] int GNR, [FromQuery] int BNR, [FromQuery] int SNR)
    {
        return Ok(new Summary(GNR, BNR, SNR));
    }
    
}
