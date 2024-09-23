using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SkillSwap.Dtos.Report;
using SkillSwap.Models;
using SkillSwap.Validations;

namespace SkillSwap.Controllers.V1.Reports;

[ApiController]
[Route("api/[controller]")]
public class ReportsPostController : ControllerBase
{
    private readonly AppDbContext _dbContext;
    private readonly IMapper _mapper;

    //Constructor
    public ReportsPostController(AppDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    /// <summary>
    /// Creates a new report.
    /// </summary>
    /// <remarks>
    /// This endpoint allows users to create a new report by providing the necessary details.
    /// The input data is validated before being saved to the database.
    /// </remarks>
    /// <param name="reportDTO">The report data transfer object containing the details of the report.</param>
    /// <returns>
    /// A 200 OK response with a success message if the report is created successfully.
    /// A 400 Bad Request response if the validation fails, with a message detailing the validation error.
    /// </returns>

    [HttpPost("PostReportCreate")]
    public async Task<IActionResult> PostReportCreate([FromBody] ReportDTO reportDTO)
    {
        // Validate the incoming report data using general validation logic
        var response = await ReportValidation.GeneralValidationAsync(reportDTO);

        // Return a 400 status code if validation fails
        if (response != "success")
        {
            return StatusCode(400, ManageResponse.ErrorBadRequest(response));
        }

        // Map the userDTO to the User model
        var report = _mapper.Map<Report>(reportDTO);

        // Set default values for report properties.
        report.DateReport = DateOnly.FromDateTime(DateTime.Now);
        report.IdState = 1;

        // Save in database
        await _dbContext.Reports.AddAsync(report);
        await _dbContext.SaveChangesAsync();

        // Return a success response after the report is created.
        return StatusCode(200, ManageResponse.Successfull("Reporte es creado exitosamente."));
    }
}