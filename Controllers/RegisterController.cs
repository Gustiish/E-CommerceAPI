using E_CommerceAPI.Models.Classes;
using E_CommerceAPI.Models.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole<Guid>> _roleManager;

        public RegisterController(UserManager<User> user, RoleManager<IdentityRole<Guid>> role)
        {
            _userManager = user;
            _roleManager = role;
        }

        [HttpPost]
        public async Task<ActionResult> RegisterUser([FromBody] RegisterUserDTO userDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(userDTO);
            }

            User user = new User()
            {
                Email = userDTO.Email,
                UserName = userDTO.Email
            };

            IdentityResult result = await _userManager.CreateAsync(user, userDTO.Password);

            if (!result.Succeeded)
                return Problem();

            var roleResult = await _userManager.AddToRoleAsync(user, "Customer");
            if (!roleResult.Succeeded)
                return Problem();

            return Created();
        }

        [HttpPost]
        public async Task<ActionResult> LoginUser([FromBody] RegisterUserDTO userDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(userDTO);
            }


        }


    }
}
