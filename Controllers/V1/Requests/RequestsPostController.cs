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
    /// create a request
    /// </summary>
    /// <remarks>
    /// method to create a request from one user to another user
    /// </remarks>
    [HttpPost("/requests")]
    public async Task<IActionResult> CreateRequest([FromBody] RequestPostDTO requestDTO)
    {
        var response = await RequestValidation.GeneralValidation(requestDTO);

        if (response != "correct")
        {
            return StatusCode(400, ManageResponse.ErrorBadRequest(response));
        }

        var request = _mapper.Map<Request>(requestDTO);

        request.IdStateRequest = 1;

        await _dbContext.Requests.AddAsync(request);
        await _dbContext.SaveChangesAsync();

        return StatusCode(200,ManageResponse.Successfull("Solicitud enviada correctamente."));
    }
}