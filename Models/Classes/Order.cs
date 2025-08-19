using E_CommerceAPI.Models.Classes.ProductProperties;

namespace E_CommerceAPI.Models.Classes
{
    public class Order
    {
        public Guid Id { get; set; }
        public required User Customer { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public required List<Product> Products { get; set; }
        public double TotalPrice { get; set; }

    }
}
