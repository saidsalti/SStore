using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SStore.Model.Data.Entities
{
    [Table(nameof(PaymentMathod))]
  
    public class PaymentMathod : BaseEntity
    {
        [Key]
        public int? Id { get; set; }
        [Required]
        [Range(1, 99999)]
        [ForeignKey("product")]
        public decimal? productPrice { get; set; }
        [Required]
        public decimal? TypesofPayment { get; set;}
    }
}



