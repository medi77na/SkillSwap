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
    /// Method to create a request from one user to another user.
    /// </remarks>
    /// <param name="requestDTO">The DTO containing the details of the request being created.</param>
    /// <returns>
    /// A 200 OK response if the request is sent successfully.
    /// A 400 Bad Request response if the validation fails.
    /// </returns>
    
    [HttpPost("PostRequestCreate")]
    public async Task<IActionResult> PostRequestCreate([FromBody] RequestPostDTO requestDTO)
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