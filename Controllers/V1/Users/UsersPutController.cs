using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SkillSwap.Dtos.User;
using SkillSwap.Models;

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
        var userFinded = await _dbContext.Users.FindAsync(id);

        if (userFinded == null)
        {
            return StatusCode(404, ManageResponse.ErrorNotFound());
        }

        _mapper.Map(userDTO, userFinded);

        await _dbContext.SaveChangesAsync();

        return Ok("User updated.");
    }
}