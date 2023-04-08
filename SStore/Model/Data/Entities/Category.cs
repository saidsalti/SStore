using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SStore.Model.Data.Entities
{
    [Table("Category")]
    public class Category : BaseEntity
    {
        public Category()
        {
            this.ProductCategories=new HashSet<ProductCategory>();
        }
        [Key]
        public int?  Id { get; set; }
        [StringLength(50)]
        [Required]
        public string? CategoryName { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
