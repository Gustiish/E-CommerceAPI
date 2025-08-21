using E_CommerceAPI.Models.Classes.ProductProperties.Enums;
using E_CommerceAPI.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_CommerceAPI.Models.Classes.ProductProperties
{
    public class Product : IEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public double Price { get; set; }
        public List<ProductImage> Images { get; set; }
        public ProductSize? Size { get; set; }
        public Dimensions? Dimensions { get; set; }
        public ProductCategory Category { get; set; }
        public int Quantity { get; set; }

    }

    [Owned]
    public record Dimensions(int Width, int Height);

}
