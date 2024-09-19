using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkillSwap.Models;

namespace SkillSwap.Controllers.V1.Requests;
[ApiController]
[Route("api/[controller]")]
public class RequestsGetController : ControllerBase
{
    private readonly AppDbContext _dbContext;

    public RequestsGetController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <summary>
    /// Obtain requests from a user
    /// </summary>
    /// <remarks>
    /// Obtain data on the requests received by a user.
    /// </remarks>
    [HttpGet("/{id}")]
    public async Task<IActionResult> GetRequestById(int id)
    {

        if (!await CheckExist(id))
        {
            return StatusCode(400, ManageResponse.ErrorBadRequest("User not found."));
        }

        var request = await _dbContext.Requests
            .Where(r => r.IdReceivingUser == id)
            .Include(r => r.IdReceivingUserNavigation)
            .Include(r => r.IdRequestingUserNavigation)
            .Include(r => r.IdStateRequestNavigation)
            .ToListAsync();

        if (request.Count != 0)
        {
            return StatusCode(404, ManageResponse.ErrorNotFound());
        }

        var lastAccepted = request.Where(r => r.IdStateRequest == 2).OrderByDescending(r => r.Id).FirstOrDefault();
        var lastPending = request.Where(r => r.IdStateRequest == 1).OrderByDescending(r => r.Id).FirstOrDefault();
        var lastCancelled = request.Where(r => r.IdStateRequest == 1).OrderByDescending(r => r.Id).FirstOrDefault();

        var countAccepted = request.Count(r => r.IdStateRequest == 2);
        var countPending = request.Count(r => r.IdStateRequest == 3);
        var countCancelled = request.Count(r => r.IdStateRequest == 1);

        var response = new
        {
            IdUsuario = id,
            NombreUsuario = request.FirstOrDefault()?.IdReceivingUserNavigation?.Name,
            Solicitudes = new
            {
                UltimaAceptada = $"{lastAccepted?.IdReceivingUserNavigation?.Name} {lastAccepted?.IdReceivingUserNavigation?.LastName}",
                UltimaPendiente = $"{lastPending?.IdReceivingUserNavigation?.Name} {lastPending?.IdReceivingUserNavigation?.LastName}",
                UltimaCancelada = $"{lastCancelled?.IdReceivingUserNavigation?.Name} {lastCancelled?.IdReceivingUserNavigation?.LastName}",
                conteoAceptadas = countAccepted,
                conteoPendientes = countPending,
                conteoCanceladas = countCancelled
            }
        };

        return StatusCode(200, ManageResponse.SuccessfullWithObject("Datos encontrados correctamente.",response));
    }

    private async Task<bool> CheckExist(int id)
    {
        var response = await _dbContext.Users.FindAsync(id);
        return response != null ? true : false;
    }

}