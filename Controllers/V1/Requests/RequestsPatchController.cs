using Microsoft.AspNetCore.Mvc;
using SkillSwap.Dtos.Request;
using SkillSwap.Models;
using SkillSwap.Validations;

namespace SkillSwap.Controllers.V1.Requests;

[ApiController]
[Route("api/[controller]")]
public class RequestsPatchController : ControllerBase
{

    private readonly AppDbContext _dbContext;

    public RequestsPatchController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    /// <summary>
    /// ACTUALIZE APPLICATION STATUS
    /// </summary>
    /// <remarks>
    /// The status of the request is updated to accepted or cancelled.
    /// </remarks>
    [HttpPatch("PatchRequestState/{id}")]
    public async Task<IActionResult> PatchRequestState(int id, [FromBody] RequestPatchDTO userDTO)
    {
        if (!await CheckExist(id))
        {
            return StatusCode(400, ManageResponse.ErrorBadRequest("User not found."));
        }

        var response = await RequestValidation.StateValidation(userDTO);

        if (response != "correct")
        {
            return StatusCode(400, ManageResponse.ErrorBadRequest(response));
        }

        var request = await _dbContext.Requests
            .FindAsync(id);

        request.IdStateRequest = userDTO.IdStateRequest;

        await _dbContext.SaveChangesAsync();

        return StatusCode(200, ManageResponse.Successfull("El estado de la solicitud fue actualizado correctamente."));
    }

    private async Task<bool> CheckExist(int id)
    {
        var response = await _dbContext.Requests.FindAsync(id);
        return response != null ? true : false;
    }
}
