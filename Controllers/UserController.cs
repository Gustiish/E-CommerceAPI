using E_CommerceAPI.Models.Classes;
using E_CommerceAPI.Models.DTOs;
using E_CommerceAPI.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole<Guid>> _roleManager;
        private readonly TokenGenerator _tokenGenerator;

        public UserController(UserManager<User> user, RoleManager<IdentityRole<Guid>> role, TokenGenerator generator)
        {
            _userManager = user;
            _roleManager = role;
            _tokenGenerator = generator;
        }


        [HttpPost]
        [Route("register")]
        public async Task<ActionResult> RegisterUser([FromBody] UserDTO userDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(userDTO);
            }

            var userExists = await _userManager.FindByEmailAsync(userDTO.Email);
            if (userExists != null)
                return Conflict("User with this email already exists.");

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
        [Route("login")]
        public async Task<ActionResult> LoginUser([FromBody] UserDTO userDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(userDTO);
            }

            User? user = await _userManager.FindByEmailAsync(userDTO.Email) ?? null;
            if (user == null)
                return NotFound();

            if (!await _userManager.CheckPasswordAsync(user, userDTO.Password))
                return Unauthorized("Wrong password");

            var roles = await _userManager.GetRolesAsync(user);


            var access_token = _tokenGenerator.GenerateToken(user.Id, user.Email, roles);
            return Ok(access_token);

        }






    }
}
