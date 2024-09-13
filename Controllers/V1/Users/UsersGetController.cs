using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkillSwap.Dtos.User;
using SkillSwap.Models;

namespace SkillSwap.Controllers.V1.Users;

[ApiController]
[Route("api/[controller]")]
public class UsersGetController : ControllerBase
{
    private readonly AppDbContext _dbContext;

    public UsersGetController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        // Obtain the users from the database and project only the desired fields.
        var users = await _dbContext.Users
            .Select(user => new UserGetDTO
            {
                Id = user.Id,
                Email = user.Email,
                Name = user.Name,
                LastName = user.LastName,
                Description = user.Description,
                JobTitle = user.JobTitle,
                UrlLinkedin = user.UrlLinkedin,
                UrlImage = user.UrlImage,
                PhoneNumber = user.PhoneNumber
            })
            .ToListAsync();

        return Ok(users);
    }

    [HttpGet("WithState")]
    public async Task<IActionResult> GetUsersAndState()
    {
        // Obtain the users from the database and project only the desired fields.
        var users = await _dbContext.Users
        .Include(user => user.IdStateNavigation)
        .Select(user => new UserGetDTO
        {
                Id = user.Id,
                Email = user.Email,
                Name = user.Name,
                LastName = user.LastName,
                Description = user.Description,
                JobTitle = user.JobTitle,
                UrlLinkedin = user.UrlLinkedin,
                UrlImage = user.UrlImage,
                PhoneNumber = user.PhoneNumber,
                IdState = user.IdState,
                StateName = user.IdStateNavigation != null ? user.IdStateNavigation.Name : "No state"
            })
            .ToListAsync();

        return Ok(users);
    }
}