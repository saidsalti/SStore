using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SStore.Model.Data.Entities
{
    [Table(nameof(OrderDetail))]
    [Index(nameof(ProductId), nameof(OrderId), IsUnique = true)]
    public class OrderDetail : BaseEntity
    {
        [Key]
        public int? Id { get; set; }
        [Required]
        [ForeignKey("Order")]
        public int? OrderId { get; set; }
        [Required]
        [ForeignKey("Product")]
        public int? ProductId { get; set; }
        [Required]
        [Range(1, 99999)]
        [ForeignKey("product")]
        public decimal? ProductPrice { get; set; }
        [Required]
        public int? Quantity { get; set; }
        [Required]
        public decimal? OrderTotalPrice { get; set; }
        public bool? IsActive { get; set; }
        public virtual Order? Order { get; set; }
        public virtual Product? Product { get; set; }


    }
}



