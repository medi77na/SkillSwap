using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SkillSwap.Dtos.Request;
using SkillSwap.Models;
using SkillSwap.Validations;

namespace SkillSwap.Controllers.V1.Requests;

[ApiController]
[Route("api/[controller]")]
public class RequestsPostController : ControllerBase
{

    private readonly AppDbContext _dbContext;
    private readonly IMapper _mapper;

    //Constructor
    public RequestsPostController(AppDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    /// <summary>
    /// Creates a request from one user to another.
    /// </summary>
    /// <remarks>
    /// method to create a request from one user to another user
    /// </remarks>
    [HttpPost("/requests")]
    public async Task<IActionResult> CreateRequest([FromBody] RequestPostDTO requestDTO)
    {

        // Validate the incoming request data using general validation logic.
        var response = await RequestValidation.GeneralValidation(requestDTO);

        // Return a 400 status code if validation fails.
        if (response != "correct")
        {
            return StatusCode(400, ManageResponse.ErrorBadRequest(response));
        }

        // Map the DTO to the Request model.
        var request = _mapper.Map<Request>(requestDTO);

        // Set the initial state for the request.
        request.IdStateRequest = 1;

        // Save the new request to the database.
        await _dbContext.Requests.AddAsync(request);
        await _dbContext.SaveChangesAsync();

        // Return a success response after the request is created.
        return StatusCode(200, ManageResponse.Successfull("Solicitud enviada correctamente."));
    }
}