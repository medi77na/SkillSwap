using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SkillSwap.Dtos.User;
using SkillSwap.Models;
using SkillSwap.Validations;
namespace SkillSwap.Controllers.V1;

[ApiController]
[Route("api/[controller]")]
public class UsersPostController : ControllerBase
{
    private readonly AppDbContext _dbContext;
    private readonly IMapper _mapper;

    //Constructor
    public UsersPostController(AppDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    /// <summary>
    /// Create a new user
    /// </summary>
    /// <remarks>
    /// Endpoint to register a new user with their personal details, abilities, and qualifications.
    /// This method also hashes the user's password before saving it to the database.
    /// </remarks>
    /// <param name="userDTO">The data transfer object (DTO) containing the user's details</param>
    /// <returns>
    /// Returns an HTTP status code:
    /// - 200 OK: If the user is successfully created and stored in the database.
    /// - 400 Bad Request: If the validation of the user data fails.
    /// The response includes a success message if the registration is successful or an error message if validation fails.
    /// </returns>
    [HttpPost("PostUserCreate")]
    public async Task<IActionResult> PostUserCreate([FromBody] UserPostDTO userDTO)
    {

        var response = await UserValidation.GeneralValidationAsync(_dbContext, userDTO);

        if (response != "correcto")
        {
            return StatusCode(400, ManageResponse.ErrorBadRequest(response));
        }
        // Create the qualification before create user with DTO properties.
        var qualification = new Qualification
        {
            Count = 0,
            AccumulatorAdition = 0
        };

        await _dbContext.Qualifications.AddAsync(qualification);
        await _dbContext.SaveChangesAsync();

        // Create the ability before create user with DTO propierties
        var abilities = new Ability
        {
            Category = userDTO.Category,
            Abilities = userDTO.Abilities
        };

        await _dbContext.Abilities.AddAsync(abilities);
        await _dbContext.SaveChangesAsync();


        // Map the userDTO to the User model
        var user = _mapper.Map<User>(userDTO);

        // Set additional properties not included in the DTO
        user.CreatedAt = DateOnly.FromDateTime(DateTime.Now);
        user.IdState = 1;
        user.IdRol = 2;
        user.IdQualification = qualification.Id;
        user.IdAbility = abilities.Id;

        // Create PasswordHasher<User> instance
        var passwordHasher = new PasswordHasher<User>();

        // Hash the password and assign it to the user's Password property
        user.Password = passwordHasher.HashPassword(user, userDTO.Password);


        // Save in database
        await _dbContext.Users.AddAsync(user);
        await _dbContext.SaveChangesAsync();

        return StatusCode(200, ManageResponse.Successfull("Usuario registrado correctamente!"));
    }
}