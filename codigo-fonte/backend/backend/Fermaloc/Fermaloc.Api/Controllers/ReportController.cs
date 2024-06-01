using System.Net;
using Fermaloc.Application;
using Microsoft.AspNetCore.Mvc;

namespace Fermaloc.Api;

[ApiController]
[Route("fermaloc/v1/reportpdf")]
public class ReportController

{

    private readonly IReportService _reportService;

    public ReportController(IReportService reportService)
    {
        _reportService = reportService;
    }

    [HttpGet]
    public async Task<IActionResult> CreateReport([FromQuery]DateOnly startDate, [FromQuery]DateOnly endDate)
    {
        var stream = await _reportService.CreateReport(startDate, endDate);
        string contentType = "application/pdf";
        string fileName = "relatorio.pdf";
        
        
        var fileContent = new FileContentResult(stream, "application/pdf")
        {
            FileDownloadName = fileName 
        };

        return fileContent;
    }
}