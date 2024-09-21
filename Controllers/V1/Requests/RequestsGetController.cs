using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkillSwap.Dtos.Request;
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
    [HttpGet("request/{id}")]
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

        if (request.Count == 0)
        {
            return StatusCode(404, ManageResponse.ErrorNotFound());
        }

        var user = await _dbContext.Users.FindAsync(id);

        var lastAccepted = request.Where(r => r.IdStateRequest == 2).OrderByDescending(r => r.Id).FirstOrDefault();
        var lastPending = request.Where(r => r.IdStateRequest == 1).OrderByDescending(r => r.Id).FirstOrDefault();
        var lastCancelled = request.Where(r => r.IdStateRequest == 3).OrderByDescending(r => r.Id).FirstOrDefault();

        var countAccepted = request.Count(r => r.IdStateRequest == 2);
        var countPending = request.Count(r => r.IdStateRequest == 1);
        var countCancelled = request.Count(r => r.IdStateRequest == 3);

        var response = new
        {
            IdUsuario = user?.Id,
            NombreUsuario = $"{user?.Name} {user?.LastName}" ?? "Nombre no disponible",
            Solicitudes = new
            {
                UltimaAceptada = $"{lastAccepted?.IdRequestingUserNavigation?.Name} {lastAccepted?.IdRequestingUserNavigation?.LastName}",
                UltimaPendiente = $"{lastPending?.IdRequestingUserNavigation?.Name} {lastPending?.IdRequestingUserNavigation?.LastName}",
                UltimaCancelada = $"{lastCancelled?.IdRequestingUserNavigation?.Name} {lastCancelled?.IdRequestingUserNavigation?.LastName}",
                conteoAceptadas = countAccepted,
                conteoPendientes = countPending,
                conteoCanceladas = countCancelled
            }
        };
        return StatusCode(200, ManageResponse.SuccessfullWithObject("Datos encontrados correctamente.", response));
    }

    /// <summary>
    /// Get messages from requests
    /// </summary>
    /// <remarks>
    /// Messages found in user requests are retrieved.
    /// </remarks>
    [HttpGet("messages{id}")]
    public async Task<IActionResult> GetMessagesById(int id)
    {
        if (!await CheckExist(id))
        {
            return StatusCode(400, ManageResponse.ErrorBadRequest("User not found."));
        }

        var requestReceiving = await _dbContext.Requests
            .Where(r => r.IdReceivingUser == id)
            .Select(r => new RequestGetMessagesDTO
            {
                Id = r.Id,
                Description = r.Description,
                IdRequestingUser = r.IdRequestingUser,
                IdReceivingUser = r.IdReceivingUser,
                UserNameRequesting = $"{r.IdRequestingUserNavigation.Name} {r.IdRequestingUserNavigation.LastName}",
                UserNameReceiving = $"{r.IdReceivingUserNavigation.Name} {r.IdReceivingUserNavigation.LastName}"
            })
            .ToListAsync();

        return StatusCode(200, ManageResponse.SuccessfullWithObject("Data encontrada", requestReceiving));
    }

    private async Task<bool> CheckExist(int id)
    {
        var response = await _dbContext.Users.FindAsync(id);
        return response != null ? true : false;
    }
}