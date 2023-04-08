using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SStore.Model.Data.Entities
{
    [Table(nameof(Payment))]
    [Index(nameof(ProductPrice), nameof(OrderTotalPrice), IsUnique = true)]
    public class Payment : BaseEntity
    {
        [Key]
        public int? Id { get; set; }
        [Required]
        [Range(1, 99999)]
        [ForeignKey("product")]
        public decimal? ProductPrice { get; set; }
        [Required]
        [ForeignKey("OrderDetail")] 
        public decimal? OrderTotalPrice { get; set; }
        

    }
}



