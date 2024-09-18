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

    [HttpPut("/{id}")]
    public async Task<IActionResult> PutByUser(int id, UserPostDTO userDTO)
    {
        if (!await CheckExist(id))
        {
            return StatusCode(400, ManageResponse.ErrorBadRequest("User not found."));
        }

        var userFinded = await UserValidation.GeneralValidationAsync(_dbContext, userDTO);

        if (userFinded != "correct user")
        {
            return StatusCode(400, ManageResponse.ErrorBadRequest(userFinded));
        }

        _mapper.Map(userDTO, userFinded);

        await _dbContext.SaveChangesAsync();

        return Ok(new
        {
            message = "User has been updated"
        });
    }


    [HttpPut("Admin/{id}")]
    public async Task<IActionResult> PutByUserFromAdmin(int id, UserPutAdminDTO userDTO)
    {
        var userFinded = await _dbContext.Users.FindAsync(id);

        if (userFinded == null)
        {
            return StatusCode(404, ManageResponse.ErrorNotFound());
        }

        _mapper.Map(userDTO, userFinded);

        await _dbContext.SaveChangesAsync();

        return Ok(new
        {
            message = "User has been updated"
        });
    }

    public async Task<bool> CheckExist(int id)
    {
        var response = await _dbContext.Users.FindAsync(id);
        return response != null ? true : false;
    }
}