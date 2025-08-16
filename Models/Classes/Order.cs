namespace E_CommerceAPI.Models.Classes
{
    public class Order
    {
        public Guid Id { get; set; }
        public User Customer { get; set; }
        public virtual List<Produt> Products { get; set; }

    }
}
