using Microsoft.AspNetCore.Mvc;
using SkillSwap.Models;

namespace SkillSwap.Controllers.V1.Users;

[ApiController]
[Route("api/[controller]")]
public class UsersDeleteController : ControllerBase
{

    private readonly AppDbContext _dbContext;

    public UsersDeleteController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteUser(int id)
    {
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