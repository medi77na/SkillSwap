using Microsoft.AspNetCore.Mvc;
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
    public IActionResult DeleteUser(int id)
    {
        // Find the user in the database by their ID
        var user = _dbContext.Users.FirstOrDefault(u => u.Id == id);

        if (user == null)
        {
            return NotFound($"User with ID {id} not found.");
        }

        _dbContext.Users.Remove(user);
        _dbContext.SaveChanges();

        return Ok($"User with ID {id} has been deleted.");
    }
}