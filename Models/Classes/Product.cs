namespace E_CommerceAPI.Models.Classes
{
    public class Product
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public double Price { get; set; }
        public int[]? Dimensions { get; set; }
        public List<ProductImage> Images { get; set; }
    }
}
