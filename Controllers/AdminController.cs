using E_CommerceAPI.Models.Classes;
using E_CommerceAPI.Models.Classes.ProductProperties;
using E_CommerceAPI.Models.DTOs;
using E_CommerceAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AdminController : ControllerBase
    {
        private readonly IGenericRepository<Product> _productRepo;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole<Guid>> _roleManager;
        public AdminController(IGenericRepository<Product> productRepo, UserManager<User> user, RoleManager<IdentityRole<Guid>> )
        {
            _productRepo = productRepo;

        }

        [HttpPost]
        [Route("create_admin")]
        public async Task<ActionResult> CreateNewAdmin([FromBody] UserDTO newUser)
        {
            if (!ModelState.IsValid)
                return BadRequest(newUser);

            var userExists = await _userManager.FindByEmailAsync(newUser.Email);
            if (userExists != null)
                return Conflict("User with this email already exists.");


            User user = new User
            {
                Email = newUser.Email,
                UserName = newUser.Email
            };
            IdentityResult result = await _userManager.CreateAsync(user, newUser.Password);
            if (!result.Succeeded)
                return Problem();
            var roleResult = await _userManager.AddToRoleAsync(user, "Admin");
            if (!roleResult.Succeeded)
                return Problem();

            return Ok();

        }

        [HttpGet]
        [Route("customers")]
        public async Task<ActionResult> GetAllCustomers()
        {

        }


    }
}
