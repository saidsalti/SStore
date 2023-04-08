using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SStore.Model.Data.Entities
{
    [Table(nameof(ProductImage))]
    public class ProductImage : BaseEntity
    {
        [Key]
        public int? Id { get; set; }
        public int? ImageStorgeId { get; set; }

        [ForeignKey("Product")]
        public int? ProductId { get; set; }

        public virtual Product? Product { get; set; }
    }
}



