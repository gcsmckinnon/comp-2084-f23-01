using System.ComponentModel.DataAnnotations;

namespace WorldDominion.Models
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; } = 0;

        [Required]
        public int? ProductId { get; set; } = 0;

        [Required]
        public string ProductName { get; set; } = String.Empty;

        [StringLength(1000)]
        public string? ProductDescription { get; set; } = String.Empty;

        [Required]
        public decimal ProductWeight { get; set; }

        [Required]
        public ProductWeightUnit ProductWeightUnit { get; set; }

        [Required]
        public int Quantity { get; set; }

        public Product? Product { get; set; } = new Product();

        public Order Order { get; set; } = new Order();
    }
}