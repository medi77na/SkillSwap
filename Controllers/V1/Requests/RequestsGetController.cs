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
    /// Obtain data on the requests received and sent by a user.
    /// </remarks>
    /// <param name="id">The ID of the user whose requests are being retrieved.</param>
    /// <returns>
    /// A 200 OK response with user and request summary data if requests are found.
    /// A 400 Bad Request response if the user is not found.
    /// A 404 Not Found response if no requests are found.
    /// </returns>

    [HttpGet("GetRequestById/{id}")]
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
        var lastAccept = request.Where(r => r.IdStateRequest == 2).OrderByDescending(r => r.Id).FirstOrDefault();
        var lastPending = request.Where(r => r.IdStateRequest == 1).OrderByDescending(r => r.Id).FirstOrDefault();
        var lastCancelled = request.Where(r => r.IdStateRequest == 3).OrderByDescending(r => r.Id).FirstOrDefault();
        var lastSent = requestSent.Where(r => r.IdStateRequest == 1).OrderByDescending(r => r.Id).FirstOrDefault();

        // Count the number of requests based on their status.
        var countReceivedAccept = request.Count(r => r.IdStateRequest == 2);
        var countReceived = request.Count(r => r.IdStateRequest == 1);
        var countCancelled = request.Count(r => r.IdStateRequest == 3);
        var countSent = requestSent.Count(r => r.IdStateRequest == 1);
        var countSentAccept = requestSent.Count(r => r.IdStateRequest == 2);

        // Prepare the response object with user and request summary data.
        var response = new
        {
            IdUsuario = user?.Id,
            NombreUsuario = $"{user?.Name} {user?.LastName}" ?? "Nombre no disponible",
            Solicitudes = new
            {
                UltimaAceptada = $"{lastAccept?.IdRequestingUserNavigation?.Name} {lastAccept?.IdRequestingUserNavigation?.LastName}",
                UltimaPendiente = $"{lastPending?.IdRequestingUserNavigation?.Name} {lastPending?.IdRequestingUserNavigation?.LastName}",
                UltimaCancelada = $"{lastCancelled?.IdRequestingUserNavigation?.Name} {lastCancelled?.IdRequestingUserNavigation?.LastName}",
                UltimoEnviado = $"{lastSent?.IdReceivingUserNavigation?.Name} {lastSent?.IdReceivingUserNavigation?.LastName}",
                conteoConexiones = countReceivedAccept + countSentAccept,
                conteoAceptadas = countSentAccept,
                conteoPendientes = countReceived,
                conteoCanceladas = countCancelled,
                conteoEnviadas = countSent
            }
        };

        // Return a successful response with the user and request data.
        return StatusCode(200, ManageResponse.SuccessfullWithObject("Datos encontrados correctamente.", response));
    }

    /// <summary>
    /// Get messages from requests.
    /// </summary>
    /// <remarks>
    /// Messages found in user requests are retrieved.
    /// </remarks>
    /// <param name="id">The ID of the user whose request messages are being retrieved.</param>
    /// <returns>
    /// A 200 OK response with the retrieved request messages if found.
    /// A 400 Bad Request response if the user is not found.
    /// </returns>
    
    [HttpGet("GetRequestMessagesById/{id}")]
    public async Task<IActionResult> GetRequestMessagesById(int id)
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
    /// Get connection data.
    /// </summary>
    /// <remarks>
    /// A Boolean is obtained from the search if two users are connected.
    /// </remarks>
    /// <param name="currectId">The ID of the current user.</param>
    /// <param name="requestId">The ID of the requesting user.</param>
    /// <returns>
    /// A 200 OK response with a Boolean indicating the connection status if found.
    /// A 400 Bad Request response if any required parameters are missing.
    /// </returns>
    
    [HttpGet("GetRequestViewDetails")]
    public async Task<IActionResult> GetRequestViewDetails(int currectId, int requestId)
    {
        if (currectId == null || requestId == null)
        {
            return StatusCode(404, ManageResponse.ErrorBadRequest);
        }

        var request = await _dbContext.Requests
                                .Where(r => r.IdReceivingUser == currectId && r.IdRequestingUser == requestId)
                                .FirstOrDefaultAsync();

        bool response;

        response = request != null && request.IdStateRequest == 2 ? true : false;

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