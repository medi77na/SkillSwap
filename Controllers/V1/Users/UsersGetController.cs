using AutoMapper;
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
    /// Get user by Id
    /// </summary>
    /// <remarks>
    /// Get a specific user by their id
    /// </remarks>
    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        // Obtain the users from the database and project only the desired fields.
        var users = await _dbContext.Users
            .Select(user => new
            {
                Id = user.Id,
                Name = user.Name,
                LastName = user.LastName,
                UrlImage = user.UrlImage,
                JobTitle = user.JobTitle,
                Description = user.Description,
                Birthdate = user.Birthdate,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                AbilityCategory = user.Ability != null ? user.Ability.Category : "No category abilities",
                Abilities = user.Ability != null ? user.Ability.Abilities : "No abilities",
                UrlLinkedin = user.UrlLinkedin,
                UrlGithub = user.UrlGithub,
                UrlBehance = user.UrlBehance,
                IdStateUser = user.IdState,
                NameStateUser = user.IdStateNavigation.Name,
                IdRoleUser = user.IdRol,
                RoleName = user.IdRol != null ? user.IdRolNavigation.Name : "No role"
            })
            .ToListAsync();

        // Return a successful response with the list of users.
        return StatusCode(200, ManageResponse.SuccessfullWithObject("Data encontrada", users));
    }

    /// <summary>
    /// Get user information for administrators
    /// </summary>
    /// <remarks>
    /// Obtain information from users with administrator privileges
    /// </remarks>
    [HttpGet("Admin")]
    public async Task<IActionResult> GetByUserFromAdmin()
    {
        var response = await _dbContext.Users
         .Select(u => new UserPutAdminDTO
         {
             Email = u.Email,
             Password = u.Password,
             Name = u.Name,
             LastName = u.LastName,
             Birthdate = u.Birthdate,
             Description = u.Description,
             JobTitle = u.JobTitle,
             UrlLinkedin = u.UrlLinkedin,
             UrlGithub = u.UrlGithub,
             UrlBehance = u.UrlBehance,
             UrlImage = u.UrlImage,
             PhoneNumber = u.PhoneNumber,
             Category = u.Ability != null ? u.Ability.Category : "No category abilities",
             Abilities = u.Ability != null ? u.Ability.Abilities : "No abilities",
             IdState = u.IdState,
             IdRol = u.IdRol
         })
        .ToListAsync();

        // Return a 200 status code with a success message and the user profile data.
        return StatusCode(200, ManageResponse.SuccessfullWithObject("Listado de usuarios", response));
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
        // Query the user from the database by ID and include their related abilities, state, and role.
        var user = await _dbContext.Users
            .Include(r => r.Ability)
            .Include(r => r.IdStateNavigation)  // Include state navigation
            .Include(r => r.IdRolNavigation)    // Include role navigation
            .FirstOrDefaultAsync(r => r.Id == id);

        // If the user is not found, return a 404 status code with a not-found error message.
        if (user == null)
        {
            return StatusCode(404, ManageResponse.ErrorNotFound());
        }

        // Create an object to structure the response data for the user.
        var getUser = new
        {
            Id = user.Id,
            Name = user.Name,
            LastName = user.LastName,
            UrlImage = user.UrlImage,
            JobTitle = user.JobTitle,
            Description = user.Description,
            Birthdate = user.Birthdate,
            Email = user.Email,
            PhoneNumber = user.PhoneNumber,
            AbilityCategory = user.Ability != null ? user.Ability.Category : "No category abilities",
            Abilities = user.Ability != null ? user.Ability.Abilities : "No abilities",
            UrlLinkedin = user.UrlLinkedin,
            UrlGithub = user.UrlGithub,
            UrlBehance = user.UrlBehance,
            IdStateUser = user.IdState,
            NameStateUser = user.IdStateNavigation != null ? user.IdStateNavigation.Name : "No state information",
            IdRoleUser = user.IdRol,
            RoleName = user.IdRolNavigation != null ? user.IdRolNavigation.Name : "No role"
        };

        // Return a successful response with the user data.
        return StatusCode(200, ManageResponse.SuccessfullWithObject("Data encontrada", getUser));
    }


    /// <summary>
    /// Get user by Id for admin
    /// </summary>
    /// <remarks>
    /// Get a specific user by their id for admin
    /// </remarks>
    [HttpGet("Admin/{id}")]
    public async Task<IActionResult> GetByUserFromAdmin(int id)
    {
        // Query the user from the database by ID and include their related abilities.
        var userFinded = await _dbContext.Users
            .Include(r => r.Ability)
            .FirstOrDefaultAsync(r => r.Id == id);

        // If the user is not found, return a 404 status code with a not-found error message.
        if (userFinded == null)
        {
            return StatusCode(404, ManageResponse.ErrorNotFound());
        }

        // Create a response object with detailed information about the user, including profile and abilities.
        var response = new
        {
            Email = userFinded.Email,
            Password = userFinded.Password,
            Name = userFinded.Name,
            LastName = userFinded.LastName,
            Birthdate = userFinded.Birthdate,
            Description = userFinded.Description,
            JobTitle = userFinded.JobTitle,
            UrlLinkedin = userFinded.UrlLinkedin,
            UrlGithub = userFinded.UrlGithub,
            UrlBehance = userFinded.UrlBehance,
            UrlImage = userFinded.UrlImage,
            PhoneNumber = userFinded.PhoneNumber,
            Category = userFinded.Ability.Category,
            Abilities = userFinded.Ability.Abilities,
            IdState = userFinded.IdState,
            IdRol = userFinded.IdRol
        };

        // Return a 200 status code with a success message and the user profile data.
        return StatusCode(200, ManageResponse.SuccessfullWithObject("El usuario ha sido encontrado", response));
    }


    [HttpGet("ForImages")]
    public async Task<IActionResult> GetUsersForImages()
    {
        // Get the requests made by each user where the request state is 2 (e.g., completed)
        var requestsMade = await _dbContext.Requests
            .Where(r => r.IdStateRequest == 2)
            .GroupBy(r => r.IdRequestingUser)
            .Select(g => new
            {
                UserId = g.Key,
                Count = g.Count()
            })
            .ToListAsync();

        // Get the requests received by each user where the request state is 2
        var requestsReceived = await _dbContext.Requests
            .Where(r => r.IdStateRequest == 2)
            .GroupBy(r => r.IdReceivingUser)
            .Select(g => new
            {
                UserId = g.Key,
                Count = g.Count()
            })
            .ToListAsync();

        // Combine the counts of requests made and received by each user
        var requestCounts = requestsMade.Concat(requestsReceived)
            .GroupBy(r => r.UserId)
            .Select(g => new
            {
                UserId = g.Key,
                Count = g.Sum(x => x.Count)
            })
            .ToList();

        // Retrieve users without performing further transformations in the query
        var users = await _dbContext.Users
            .Include(u => u.Qualification)
            .Include(u => u.Ability)
            .Select(u => new
            {
                Id = u.Id,
                FullName = $"{u.Name} {u.LastName}",
                JobTitle = u.JobTitle,
                Qualification = new
                {
                    Count = u.Qualification.Count,
                    acummulator = u.Qualification.AccumulatorAdition
                },
                Description = u.Description,
                Abilities = u.Ability.Abilities,
                Image = u.UrlImage
            })
            .ToListAsync();

        // Project and process the data in memory
        var userDtos = users.Select(u => new UserGetForImagesDTO
        {
            Id = u.Id,
            FullName = u.FullName,
            JobTitle = u.JobTitle,
            Qualification = u.Qualification.Count > 0 ? (double)u.Qualification.acummulator / u.Qualification.Count : 0,
            CountMatches = requestCounts.Count,
            Description = u.Description,
            Abilities = u.Abilities,
            UrlImage = u.Image
        }).ToList();

        return StatusCode(200, ManageResponse.SuccessfullWithObject("Data encontrada", userDtos));
    }
    [HttpGet("GetUserSortDate")]
    public async Task<IActionResult> GetUserSortedCreated()
    {
        var users = await _dbContext.Users
        .Include(a => a.Ability)
        .Select(u => new
        {
            Id = u.Id,
            Name = $"{u.Name} {u.LastName}",
            UrlImage = u.UrlImage,
            Category = u.Ability.Category,
            CreatedAt = u.CreatedAt
        }).OrderByDescending(u => u.CreatedAt)
        .ToListAsync();

        return Ok(users);
    }

    [HttpGet("Admin/{id}")]
    public async Task<IActionResult> GetByUserFromAdmin(int id)
    {

        // Query the user from the database by ID and include their related abilities.
        var userFinded = await _dbContext.Users
            .Include(r => r.Ability)
            .FirstOrDefaultAsync(r => r.Id == id);

        // If the user is not found, return a 404 status code with a not-found error message.
        if (userFinded == null)
        {
            return StatusCode(404, ManageResponse.ErrorNotFound());
        }

        // Create a response object with detailed information about the user, including profile and abilities.
        var response = new
        {
            Email = userFinded.Email,
            Password = userFinded.Password,
            Name = userFinded.Name,
            LastName = userFinded.LastName,
            Birthdate = userFinded.Birthdate,
            Description = userFinded.Description,
            JobTitle = userFinded.JobTitle,
            UrlLinkedin = userFinded.UrlLinkedin,
            UrlGithub = userFinded.UrlGithub,
            UrlBehance = userFinded.UrlBehance,
            UrlImage = userFinded.UrlImage,
            PhoneNumber = userFinded.PhoneNumber,
            Category = userFinded.Ability.Category,
            Abilities = userFinded.Ability.Abilities,
            IdState = userFinded.IdState,
            IdRol = userFinded.IdRol,
            SuspensionDate = userFinded.SuspensionDate,
            ReactivationDate = userFinded.ReactivationDate
        };

        // Return a 200 status code with a success message and the user profile data.
        return StatusCode(200, ManageResponse.SuccessfullWithObject("El usuario ha sido encontrado", response));
    }
}