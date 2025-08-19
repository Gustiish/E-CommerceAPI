using E_CommerceAPI.Models.Classes.ProductProperties.Enums;

namespace E_CommerceAPI.Models.Classes.ProductProperties
{
    public class Product
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public double Price { get; set; }
        public List<ProductImage> Images { get; set; }
        public ProductSize? Size { get; set; }
        public Dimensions? Dimensions { get; set; }
        public ProductCategory Category { get; set; }

    }

    public record Dimensions(int Width, int Height);

}
