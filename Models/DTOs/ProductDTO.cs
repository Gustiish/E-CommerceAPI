using E_CommerceAPI.Models.Classes.ProductProperties;
using E_CommerceAPI.Models.Classes.ProductProperties.Enums;

namespace E_CommerceAPI.Models.DTOs
{
    public class ProductDTO
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public List<ProductImage> Images { get; set; }
        public ProductSize? Size { get; set; }
        public DimensionsDTO? Dimensions { get; set; }
        public ProductCategory Category { get; set; }
    }

    public record DimensionsDTO(int width, int height);
}
