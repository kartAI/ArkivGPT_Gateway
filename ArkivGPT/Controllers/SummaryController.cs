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
    public ActionResult<CaseData> Get([FromQuery] int gnr, [FromQuery] int bnr, [FromQuery] int snr)
    {
        var summary = new List<SummaryElement>()
        {
            new SummaryElement(new DateOnly(2020, 5, 2), "Test resolution 1", "http://test1"),
            new SummaryElement(new DateOnly(2021, 6, 1), "Test resolution 2", "http://test2")
        };

        var propertyInfo = new PropertyInfo()
        {
            Gnr = gnr,
            Bnr = bnr,
            Snr = snr,
            Address = "Test address"
        };



        var caseData = new CaseData(summary, propertyInfo);
        


        return Ok(caseData);
    }
    
}
