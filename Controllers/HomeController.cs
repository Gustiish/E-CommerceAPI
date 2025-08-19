using E_CommerceAPI.Models.Classes.ProductProperties;
using E_CommerceAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IGenericRepository<Product> _productRepo;

        public HomeController(IGenericRepository<Product> productRepo)
        {
            _productRepo = productRepo;
        }
    }
}

