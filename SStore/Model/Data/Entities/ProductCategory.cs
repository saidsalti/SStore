using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SStore.Model.Data.Entities
{
    [Table(nameof(ProductCategory))]
    [Index(nameof(ProductId), nameof(CategoryId), IsUnique = true)]
    public class ProductCategory : BaseEntity
    {
        [Key]
        public int? Id { get; set; }
        [ForeignKey("Product")]
        [Required]
        public int? ProductId { get; set; }

        [Required]
        public int? CategoryId { get; set; }
        public virtual Category? Category { get; set; }
        public virtual Product? Product { get; set; }
    }
}



