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

    [HttpPost]
    public async Task<IActionResult> CreateReport([FromBody] ReportPostDTO reportDTO)
    {

        var response = await ReportValidation.GeneralValidationAsync(reportDTO);

        if (response != "correct report")
        {
            return StatusCode(400, ManageResponse.ErrorBadRequest(response));
        }

        // Map the userDTO to the User model
        var report = _mapper.Map<Report>(reportDTO);

        // Save in database
        await _dbContext.Reports.AddAsync(report);
        await _dbContext.SaveChangesAsync();

        return Ok(ManageResponse.Successfull("User registered successfully."));
    }
}