using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace ArkivGPT_Gateway.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class DocumentController : ControllerBase
{

    private readonly ILogger<DocumentController> _logger;

    public DocumentController(ILogger<DocumentController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public async Task Get([FromQuery] string document)
    {
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Files", document);
        _logger.LogInformation(filePath);
        
        if (!System.IO.File.Exists(filePath))
        {
            Response.StatusCode = 404;
            await Response.WriteAsync($"File '{document}' not found.");
            return;
        }

        using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
        {
            Response.ContentType = "application/octet-stream";
            Response.ContentLength = fileStream.Length;
            Response.StatusCode = 200;
            await fileStream.CopyToAsync(Response.Body);
        }
    }
}
