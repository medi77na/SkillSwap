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
    /// Retrieve all users with detailed information
    /// </summary>
    /// <remarks>
    /// Endpoint to get a list of all users with their personal details, abilities, state, and role information.
    /// </remarks>
    /// <returns>
    /// Returns an HTTP status code:
    /// - 200 OK: If the list of users is successfully retrieved.
    /// The response contains a detailed list of users with various attributes such as abilities, roles, and states.
    /// </returns>
    [HttpGet("GetUsersAll")]
    public async Task<IActionResult> GetUsersAll()
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
                Category = user.Ability != null ? user.Ability.Category : "No category abilities",
                Abilities = user.Ability != null ? user.Ability.Abilities : "No abilities",
                UrlLinkedin = user.UrlLinkedin,
                UrlGithub = user.UrlGithub,
                UrlBehance = user.UrlBehance,
                IdStateUser = user.IdState,
                IdRoleUser = user.IdRol,
                SuspensionDate = user.SuspensionDate,
                ReactivationDate = user.ReactivationDate,
                NameStateUser = user.IdStateNavigation.Name,
                RoleName = user.IdRol != null ? user.IdRolNavigation.Name : "No role"

            })
            .ToListAsync();

        // Return a successful response with the list of users.
        return StatusCode(200, ManageResponse.SuccessfullWithObject("Data encontrada", users));
    }

    /// <summary>
    /// Retrieve a user by their ID
    /// </summary>
    /// <remarks>
    /// Endpoint to fetch a user based on their unique ID, including their personal details, abilities, state, and role.
    /// </remarks>
    /// <param name="id">The ID of the user to retrieve</param>
    /// <returns>
    /// Returns an HTTP status code:
    /// - 200 OK: If the user is found and successfully retrieved.
    /// - 404 Not Found: If the user with the specified ID does not exist.
    /// The response includes the user's detailed information including their abilities, roles, and status.
    /// </returns>
    [HttpGet("GetUserById/{id}")]
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
            Category = user.Ability != null ? user.Ability.Category : "No category abilities",
            Abilities = user.Ability != null ? user.Ability.Abilities : "No abilities",
            UrlLinkedin = user.UrlLinkedin,
            UrlGithub = user.UrlGithub,
            UrlBehance = user.UrlBehance,
            IdStateUser = user.IdState,
            IdRoleUser = user.IdRol,
            SuspensionDate = user.SuspensionDate,
            ReactivationDate = user.ReactivationDate,
            NameStateUser = user.IdStateNavigation.Name,
            RoleName = user.IdRol != null ? user.IdRolNavigation.Name : "No role"
        };

        // Return a successful response with the user data.
        return StatusCode(200, ManageResponse.SuccessfullWithObject("Data encontrada", getUser));
    }

    /// <summary>
    /// Retrieve users with images and request counts
    /// </summary>
    /// <remarks>
    /// Endpoint to fetch users along with their images, qualifications, abilities, and request counts (requests made and received).
    /// </remarks>
    /// <returns>
    /// Returns an HTTP status code:
    /// - 200 OK: If the user data with images and request counts is successfully retrieved.
    /// The response contains users' personal details, qualifications, abilities, and a count of requests made and received.
    /// </returns>
    [HttpGet("GetUsersForImages")]
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
            CountMatches = requestCounts.FirstOrDefault(r => r.UserId == u.Id) ? .Count ?? 0,
            Description = u.Description,
            Abilities = u.Abilities,
            UrlImage = u.Image
        }).ToList();

        return StatusCode(200, ManageResponse.SuccessfullWithObject("Data encontrada", userDtos));
    }

    /// <summary>
    /// Retrieve users sorted by creation date
    /// </summary>
    /// <remarks>
    /// Endpoint to get a list of users sorted by their creation date in descending order.
    /// </remarks>
    /// <returns>
    /// Returns an HTTP status code:
    /// - 200 OK: If the list of users sorted by creation date is successfully retrieved.
    /// The response contains a list of users with their names, abilities, categories, and creation dates.
    /// </returns>
    [HttpGet("GetUserSortedCreated")]
    public async Task<IActionResult> GetUserSortedCreated()
    {
        // Obtain and organize users in descending order of creation
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
}