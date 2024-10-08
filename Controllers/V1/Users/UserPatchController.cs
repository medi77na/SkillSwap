using Microsoft.AspNetCore.Mvc;
using SkillSwap.Models;

namespace SkillSwap.Controllers.V1.Users;
[ApiController]
[Route("api/[controller]")]
public class UserPatchController : ControllerBase
{
    private readonly AppDbContext _dbContext;

    public UserPatchController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <summary>
    /// Modify user account status to suspended
    /// </summary>
    /// <remarks>
    /// Endpoint to modify the status of a user account, setting it to suspended.
    /// </remarks>
    /// <param name="id">The ID of the user whose status will be modified</param>
    /// <returns>
    /// Returns an HTTP status code:
    /// - 200 OK: If the user's account is already suspended or successfully suspended.
    /// - 404 Not Found: If the user does not exist.
    /// The response includes either a success message or an error, along with the user's updated details.
    /// </returns>
    [HttpPatch("PatchUserAccountSuspend")]
    public async Task<IActionResult> PatchUserAccountSuspend(int id)
    {
        // Find the user by ID
        var userFind = await _dbContext.Users.FindAsync(id);

        // If the user does not exist, return a 404 status with an error message.
        if (userFind == null)
        {
            return StatusCode(404, ManageResponse.ErrorNotFound());
        }

        // If the user account is already suspended, return a 200 status with a success message.
        if (userFind.IdState == 3)
        {
            return StatusCode(200, ManageResponse.Successfull("La cuenta ya se encuentra suspendida"));
        }

            // If the user account is already suspended, return a 200 status with a success message.
            userFind.IdState = 3;
            userFind.SuspensionDate = DateOnly.FromDateTime(DateTime.Now);
            userFind.ReactivationDate = (userFind.SuspensionDate ?? DateOnly.FromDateTime(DateTime.Now)).AddDays(5);
        

        // Create a response object with user information.
        await _dbContext.SaveChangesAsync();

        // Return a 200 status with a success message and user details.
        var response = new
        {
            id = userFind.IdState,
            nombre = userFind.Name,
            estado = "suspendido"
        };

        return StatusCode(200, ManageResponse.SuccessfullWithObject("Cuenta suspendida con éxito", response));
    }
}
