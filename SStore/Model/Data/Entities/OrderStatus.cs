using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SStore.Model.Data.Entities
{
    [Table(nameof(OrderStatus))]
    [Index(nameof(ProductId), nameof(OrderId), IsUnique = true)]
    public class OrderStatus : BaseEntity
    {
        [Key]
        public int? Id { get; set; }
        [StringLength(50)]
        [Required]
        public string? OrderStatusNo { get; set; }

        [Required]
        [ForeignKey("Order")]
        public int? OrderId { get; set; }

        [Required]
        [ForeignKey("Product")]
        public int? ProductId { get; set; }

        [Required]
        public int? location { get; set; }

        public bool? IsActive { get; set; }
        public virtual Order? Order { get; set; }
        public virtual OrderStatus? Status { get; set; }
        public virtual Product? Product { get; set; }
    }
}



