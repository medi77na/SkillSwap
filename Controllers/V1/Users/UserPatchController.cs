using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SkillSwap.Models;

namespace SkillSwap.Controllers.V1.Users
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserPatchController : ControllerBase
    {
        private readonly AppDbContext _dbContext;

        public UserPatchController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPatch("PatchUserAccountSuspend")]
        public async Task<IActionResult> PatchUserAccountSuspend(int id)
        {
            // Find the user by ID
            var userFind = await _dbContext.Users.FindAsync(id);

            // If the user does not exist, return a 404 status with an error message.
            if (userFind == null)
            {
                return StatusCode(404, ManageResponse.ErrorNotFound());
            }

            // If the user account is already suspended, return a 200 status with a success message.
            if (userFind.IdState == 3)
            {
                return StatusCode(200, ManageResponse.Successfull("La cuenta ya se encuentra suspendida"));
            }

            // If the user account is already suspended, return a 200 status with a success message.
            userFind.IdState = 3;

            // Create a response object with user information.
            await _dbContext.SaveChangesAsync();

            // Return a 200 status with a success message and user details.
            var response = new
            {
                id = userFind.IdState,
                nombre = userFind.Name,
                estado = "suspendido"
            };

            return StatusCode(200, ManageResponse.SuccessfullWithObject("Cuenta suspendida con éxito", response));
        }



    }
}