using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        return StatusCode(200, ManageResponse.Successfull("El usuario ha sido actulizado"));
    }

    [HttpPut("PutUserAction")]
    public async Task<IActionResult> PutUserAction(int id, string action)
    {

        string message ="";

        // Find the user by ID, including the user's state navigation
        var userFind = await _dbContext.Users
            .Include(r => r.IdStateNavigation)
            .FirstOrDefaultAsync(i => i.Id == id);

        // Prepare response object with current user information
        var response = new
        {
            id = userFind.IdState,
            nombre = userFind.Name,
            estado = userFind.IdStateNavigation.Name
        };

        // If the user does not exist, return a 404 status with an error message
        if (userFind == null)
        {
            return StatusCode(404, ManageResponse.ErrorNotFound());
        }

        // Update user state based on the action input ("habilitar" or "deshabilitar")

        if (action.Equals("habilitar", StringComparison.OrdinalIgnoreCase))
        {

            // If the user is already enabled, return a success message without updating
            if (userFind.IdState == 1)
            {
                return StatusCode(200, ManageResponse.SuccessfullWithObject("El usuario reportado ya se encuentra habilitado", response));
            }
            userFind.IdState = 1;
            message = "El estado de la cuenta ha sido habilitada";

        }
        if (action.Equals("deshabilitar", StringComparison.OrdinalIgnoreCase))
        {
            // If the user is already disabled, return a success message without updating
            if (userFind.IdState == 2)
            {
                return StatusCode(200, ManageResponse.SuccessfullWithObject("El usuario reportado ya se encuentra deshabilitado", response));
            }
             userFind.IdState = 2;
             message = "El estado de la cuenta ha sido deshabilitada";
        }

        // Save changes to the database
        await _dbContext.SaveChangesAsync();

        // Retrieve updated user information
        var userFind2 = await _dbContext.Users
            .Include(r => r.IdStateNavigation)
            .FirstOrDefaultAsync(i => i.Id == id);

        // Prepare response object with updated user information
        response = new
        {
            id = userFind2.IdState,
            nombre = userFind2.Name,
            estado = userFind2.IdStateNavigation.Name
        };

        // Return a 200 status with a success message and user details.
        return StatusCode(200, ManageResponse.SuccessfullWithObject("Cuenta suspendida con éxito", response));
    }

    /// Checks if a user exists based on their ID.
    private async Task<bool> CheckExist(int id)
    {
        var response = await _dbContext.Users.FindAsync(id);
        return response != null ? true : false;
    }
}