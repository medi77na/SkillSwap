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

    // Endpoint to delete a user by their ID
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        // Find the user in the database by their ID
        var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);

        if (user == null)
        {
            return StatusCode(404,ManageResponse.ErrorNotFound());
        }

        _dbContext.Users.Remove(user);
        await _dbContext.SaveChangesAsync();

        return StatusCode(200,ManageResponse.Successfull($"Usuario con id {id} ha sido eliminado."));
    }
}