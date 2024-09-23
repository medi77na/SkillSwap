using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkillSwap.Models;

namespace SkillSwap.Controllers.V1.Users;

[ApiController]
[Route("api/[controller]")]
public class UsersDeleteController : ControllerBase
{
    private readonly AppDbContext _dbContext;

    //Constructor
    public UsersDeleteController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <summary>
    /// Delete a user by their ID
    /// </summary>
    /// <remarks>
    /// Endpoint to delete a user from the system based on their unique ID.
    /// </remarks>
    /// <param name="id">The ID of the user to be deleted</param>
    /// <returns>
    /// Returns an HTTP status code:
    /// - 200 OK: If the user was successfully deleted.
    /// - 404 Not Found: If the user does not exist.
    /// The response includes a success message or an error message.
    /// </returns>
    [HttpDelete("DeleteUserById")]
    public async Task<IActionResult> DeleteUserById(int id)
    {
        // Find the user in the database by their ID
        var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);

        // If the user is not found, return a 404 Not Found response.
        if (user == null)
        {
            return StatusCode(404, ManageResponse.ErrorNotFound());
        }

        // Remove the user from the database context.
        _dbContext.Users.Remove(user);

        // Save the changes to the database.
        await _dbContext.SaveChangesAsync();

        // Return a success message indicating the user has been deleted.
        return StatusCode(200, ManageResponse.Successfull($"Usuario con id {id} ha sido eliminado."));
    }
}