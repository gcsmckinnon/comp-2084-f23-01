using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorldDominion.Models
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; } = 0;

        [Required]
        public int OrderId { get; set; } = 0;

        [Required]
        public string ProductName { get; set; } = String.Empty;

        [Required]
        public int Quantity { get; set; }

        [ForeignKey("OrderId")]
        public virtual Order? Order { get; set; };
    }
}