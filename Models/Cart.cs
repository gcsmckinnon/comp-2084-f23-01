namespace WorldDominion.Models
{
    public class Cart
    {
        public List<CartItem> CartItems { get; set; } = new List<CartItem>();

        public int? OrderId { get; set; } = 0;
    }
}