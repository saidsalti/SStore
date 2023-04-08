using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SStore.Model.Data.Entities
{
    [Table(nameof(Order))]
    public class Order : BaseEntity
    {
        public Order()
        {
            this.OrderDetals = new HashSet<OrderDetail>();
        }
        [Key]
        public int? Id { get; set; }
        [Required]
        public int? OrderId { get; set; }
        [Required]
        public DateTime? OrderCreated { get; set; }
        [Required]
        public int? OrderUserId { get; set; }
        [Required]
        public int? OrderStatusId { get; set; }
        [Required]
        public decimal? OrderTotalPrice { get; set; }
        [Required]
        public bool? IsActive { get; set; }
        public virtual ICollection<OrderDetail> OrderDetals { get; set; }

    }
}



