using SStore.Model.Data.Entities;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SStore.Model.Data.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage =" اسم المنتج مطلوب للإدخال")]
        public string? ProductName { get; set; }     
        [Required(ErrorMessage ="سعر المنتج مطلوب للإدخال")]

        public decimal? ProductPrice { get; set; }
        // نشر أم لا
        public bool? IsActive { get; set; }       
        public int? ProductImageId { get; set; }
        // الكمية
        [Required(ErrorMessage = "الكمية مطلوبة للإدخال")]

        public int? Quantity { get; set; }

        // مسار الصورة الخاصة بالمنتج
        public string? ProductImagePath { get; set; }
        public DateTime? Created { get; set; }

        public List<int>? CategoryIdes { get; set; }

        // تجاهل عند التحويل الى json
        [JsonIgnore]
        public Product ToProduct =>
            new Product
            {
                IsActive = IsActive,
                ProductName = ProductName,
                Quantity = Quantity,
                ProductPrice = ProductPrice,

            };

        public static ProductDto toDto(Product product) =>
            new ProductDto
            {
                Id = product.Id,
                IsActive = product.IsActive,
                ProductImageId = product.ProductImageId,
                ProductName = product.ProductName,
                ProductPrice = product.ProductPrice,
                Quantity = product.Quantity,

            };
    }
}
