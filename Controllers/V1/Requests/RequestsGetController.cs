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
    /// Retrieves requests associated with a specific user.
    /// </summary>
    /// <remarks>
    /// Obtain data on the requests received by a user.
    /// </remarks>
    [HttpGet("request/{id}")]
    public async Task<IActionResult> GetRequestById(int id)
    {

        // Check if the user exists in the database.
        if (!await CheckExist(id))
        {
            return StatusCode(400, ManageResponse.ErrorBadRequest("User not found."));
        }

        // Retrieve received requests for the user.
        var request = await _dbContext.Requests
            .Where(r => r.IdReceivingUser == id)
            .Include(r => r.IdReceivingUserNavigation)
            .Include(r => r.IdRequestingUserNavigation)
            .Include(r => r.IdStateRequestNavigation)
            .ToListAsync();

        // Retrieve sent requests from the user.
        var requestSent = await _dbContext.Requests
            .Where(r => r.IdRequestingUser == id)
            .Include(r => r.IdReceivingUserNavigation)
            .ToListAsync();

        // Return a 404 status if no requests are found.
        if (request.Count == 0 && requestSent.Count == 0)
        {
            return StatusCode(404, ManageResponse.ErrorNotFound());
        }

        // Retrieve user details from the database.
        var user = await _dbContext.Users.FindAsync(id);

        // Get the last requests of each type based on their status.
        var lastAccepted = request.Where(r => r.IdStateRequest == 2).OrderByDescending(r => r.Id).FirstOrDefault();
        var lastPending = request.Where(r => r.IdStateRequest == 1).OrderByDescending(r => r.Id).FirstOrDefault();
        var lastCancelled = request.Where(r => r.IdStateRequest == 3).OrderByDescending(r => r.Id).FirstOrDefault();
        var lastSent = requestSent.Where(r => r.IdStateRequest == 1).OrderByDescending(r => r.Id).FirstOrDefault();

        // Count the number of requests based on their status.
        var countAccepted = request.Count(r => r.IdStateRequest == 2);
        var countReceived = request.Count(r => r.IdStateRequest == 1);
        var countCancelled = request.Count(r => r.IdStateRequest == 3);
        var countSent = requestSent.Count(r => r.IdStateRequest == 1);

        // Prepare the response object with user and request summary data.
        var response = new
        {
            IdUsuario = user?.Id,
            NombreUsuario = $"{user?.Name} {user?.LastName}" ?? "Nombre no disponible",
            Solicitudes = new
            {
                UltimaAceptada = $"{lastAccepted?.IdRequestingUserNavigation?.Name} {lastAccepted?.IdRequestingUserNavigation?.LastName}",
                UltimaPendiente = $"{lastPending?.IdRequestingUserNavigation?.Name} {lastPending?.IdRequestingUserNavigation?.LastName}",
                UltimaCancelada = $"{lastCancelled?.IdRequestingUserNavigation?.Name} {lastCancelled?.IdRequestingUserNavigation?.LastName}",
                UltimoEnviado = $"{lastSent?.IdReceivingUserNavigation?.Name} {lastSent?.IdReceivingUserNavigation?.LastName}",
                conteoAceptadas = countAccepted,
                conteoPendientes = countReceived,
                conteoCanceladas = countCancelled,
                conteoEnviadas = countSent
            }
        };

        // Return a successful response with the user and request data.
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

    /// <summary>
    /// Get connection data
    /// </summary>
    /// <remarks>
    /// A Boolean is obtained from the search if two users are connected.
    /// </remarks>
    [HttpGet("ViewDetails")]
    public async Task<IActionResult> GetViewDetails(int currectId, int requestId)
    {
        if (currectId == null || requestId == null)
        {
            return StatusCode(404, ManageResponse.ErrorBadRequest);
        }

        var request = await _dbContext.Requests
                                .Where(r => r.IdReceivingUser == currectId && r.IdRequestingUser == requestId)
                                .FirstOrDefaultAsync();

        if (request == null)
        {
            return StatusCode(404, ManageResponse.ErrorNotFound());                   
        }

        var stateRequest = request.IdStateRequest;
        bool response = true;

        if(stateRequest == 2)
        {
            response = true;
        }

        return StatusCode(200, ManageResponse.SuccessfullWithObject("Data encontrada", response));
    }

    /// Checks if a user exists in the database.
    private async Task<bool> CheckExist(int id)
    {
        // Check if the user exists by attempting to find it in the database.
        var response = await _dbContext.Users.FindAsync(id);
        return response != null ? true : false;
    }
}