using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
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


    /// <summary>
    /// GENERAL INFORMATION
    /// </summary>
    /// <remarks>
    /// Obtain general information from all system users
    /// </remarks>
    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        // Obtain the users from the database and project only the desired fields.
        var users = await _dbContext.Users
            .Select(user => new UserGetDTO
            {
                Id = user.Id,
                Name = user.Name,
                LastName = user.LastName,
                JobTitle = user.JobTitle,
                Description = user.Description,
                Birthdate = user.Birthdate,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                AbilityCategory = user.Ability != null ? user.Ability.Category : "No abilities",
                UrlLinkedin = user.UrlLinkedin,
                UrlGithub = user.UrlGithub,
                UrlBehance = user.UrlBehance,
                RoleName = user.IdRol != null ? user.IdRolNavigation.Name : "No role"
            })
            .ToListAsync();
         return StatusCode(200,ManageResponse.SuccessfullWithObject("Data encontrada", users));
    }


    /// <summary>
    /// Get user by Id
    /// </summary>
    /// <remarks>
    /// Get a specific user by their id
    /// </remarks>

    [HttpGet("/{id}")]
    public async Task<IActionResult> GetUserById(int id)
    {
        var user = await _dbContext.Users
        .Include(u => u.Ability)
        .Include(u => u.IdRolNavigation)
        .FirstOrDefaultAsync(u => u.Id == id);

        if (user == null)
        {
            return StatusCode(404, ManageResponse.ErrorNotFound());
        }

        var getUser = new UserGetDTO
        {
            Id = user.Id,
            Name = user.Name,
            LastName = user.LastName,
            JobTitle = user.JobTitle,
            Description = user.Description,
            Birthdate = user.Birthdate,
            Email = user.Email,
            PhoneNumber = user.PhoneNumber,
            AbilityCategory = user.Ability != null ? user.Ability.Category : "No abilities",
            UrlLinkedin = user.UrlLinkedin,
            UrlGithub = user.UrlGithub,
            UrlBehance = user.UrlBehance,
            RoleName = user.IdRol != null ? user.IdRolNavigation.Name : "No role"
        };
        return StatusCode(200,ManageResponse.SuccessfullWithObject("Data encontrada", getUser));
    }


    /// <summary>
    /// Get state from user
    /// </summary>
    /// <remarks>
    /// obtain the user's current status
    /// </remarks>
    [HttpGet("/state/{id}")]
    public async Task<IActionResult> GetStateFromUser(int id)
    {
        var user = await _dbContext.Users
           .Include(u => u.IdStateNavigation)
           .FirstOrDefaultAsync(u => u.Id == id);

        if (user == null)
        {
            return StatusCode(404, ManageResponse.ErrorNotFound());
        }

        var getUser = new UserStateDTO
        {
            Id = user.Id,
            StateName = user.IdState != null ? user.IdStateNavigation.Name : "No state"
        };

        return StatusCode(200,ManageResponse.SuccessfullWithObject("Data encontrada", getUser));
    }

    private async Task<bool> CheckExist(int id)
    {
        var response = await _dbContext.Users.FindAsync(id);
        return response != null ? true : false;
    }

}