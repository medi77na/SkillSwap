using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SkillSwap.Dtos.User;
using SkillSwap.Models;
using SkillSwap.Validations;

namespace SkillSwap.Controllers.V1.Users;
[ApiController]
[Route("api/[controller]")]
public class UsersPutController : ControllerBase
{

    private readonly AppDbContext _dbContext;
    private readonly IMapper _mapper;

    //Constructor
    public UsersPutController(AppDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    /// Updates a user based on the provided user ID.
    [HttpPut("{id}")]
    public async Task<IActionResult> PutByUser(int id, UserPostDTO userDTO)
    {

        // Check if the user exists in the database by ID
        if (!await CheckExist(id))
        {
            return StatusCode(400, ManageResponse.ErrorBadRequest("User not found."));
        }

        // Validate the user data provided in the DTO.
        var userFinded = await UserValidation.GeneralValidationAsync(_dbContext, userDTO);

        // If validation fails, return a 400 Bad Request response.
        if (userFinded != "correct user")
        {
            return StatusCode(400, ManageResponse.ErrorBadRequest(userFinded));
        }

        // Map the updated data from the DTO to the found user entity.
        _mapper.Map(userDTO, userFinded);

        // Save the changes to the database.
        await _dbContext.SaveChangesAsync();

        // Return a success message indicating that the user has been updated.
        return StatusCode(200, ManageResponse.Successfull("El usuario ha sido actulizado"));
    }

    /// Updates a user based on the provided user ID from the admin perspective.
    [HttpPut("Admin/{id}")]
    public async Task<IActionResult> PutByUserFromAdmin(int id, UserPutAdminDTO userDTO)
    {

        // Attempt to find the user in the database by ID.
        var userFinded = await _dbContext.Users.FindAsync(id);

        // If the user is not found, return a 404 Not Found response.
        if (userFinded == null)
        {
            return StatusCode(404, ManageResponse.ErrorNotFound());
        }

        // Map the updated data from the DTO to the found user entity.
        _mapper.Map(userDTO, userFinded);

        // Save the changes to the database.
        await _dbContext.SaveChangesAsync();

        // Return a success message indicating that the user has been updated.
        return StatusCode(200, ManageResponse.Successfull("El usuario ha sido actualizado"));
    }

    /// Checks if a user exists based on their ID.
    private async Task<bool> CheckExist(int id)
    {
        var response = await _dbContext.Users.FindAsync(id);
        return response != null ? true : false;
    }
}