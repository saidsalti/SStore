using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SStore.Model.Data.Entities
{
    [Table(nameof(Product))]
    public class Product : BaseEntity
    {
        public Product()
        {
            this.ProductCategories = new HashSet<ProductCategory>();
            this.OrderDetails = new HashSet<OrderDetail>();
            this.ProductImages = new HashSet<ProductImage>();

        }
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        [Required]
        public string? ProductName { get; set; }

        [Required]
        [Range(1, 99999)]
        public decimal? ProductPrice { get; set; }

        public bool? IsActive { get; set; }
        // from storge
        public int? ProductImageId { get; set; }
        public int? Quantity { get; set; }

        public virtual ICollection<ProductCategory> ProductCategories { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<ProductImage> ProductImages { get; set; }
       
        public virtual ICollection<OrderStatus> OrderStatus { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<PaymentMathod> PaymentMathods { get; set; }
    }  
}



