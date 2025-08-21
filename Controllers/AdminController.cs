using E_CommerceAPI.Models.Classes.ProductProperties;
using E_CommerceAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AdminController : ControllerBase
    {
        private readonly IGenericRepository<Product> _productRepo;
        public AdminController(IGenericRepository<Product> productRepo)
        {
            _productRepo = productRepo;

        }

        //[HttpPost]
        //public async Task<IActionResult> RegisterProduct([FromBody] ProductDTO product)
        //{

        //}

    }
}
