using SStore.Model.Data.Entities;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SStore.Model.Data.Dtos
{
    public class AppUserDto
    {
      
        public int Id { get; set; }
        [StringLength(50 , ErrorMessage ="عدد الأحرف المخصصة فقط 50 حرفا") ]
        [Required(ErrorMessage ="مطلوب للإدخال")]
        public string? UserName { get; set; }
        [StringLength(500)]
        [Required(ErrorMessage = "مطلوب للإدخال")]

        public string? Email { get; set; }
        [StringLength(50,ErrorMessage = "عدد الأحرف المخصصة فقط 50 حرفا")]
        [Required(ErrorMessage = "مطلوب للإدخال")]

        public string? FirstName { get; set; }
        [StringLength(50,ErrorMessage = "عدد الأحرف المخصصة فقط 50 حرفا")]
        [Required(ErrorMessage = "مطلوب للإدخال")]

        public string? LastName { get; set; }
        [Required(ErrorMessage ="رقم الهاتف مطلوب للإدخال")]
        [RegularExpression(@"^\d{8,}$",ErrorMessage ="يرجى ادخال رقم هاتف صحيح يتكون من 8 ارقام")]
        public string? PhoneNumber { get; set; }
        // public bool? IsActive { get; set; }
        [Required(ErrorMessage = "مطلوب للإدخال")]
        [MinLength(8,ErrorMessage ="كلمة المرور يجب أن لا تقل عن 8 احرف وارقام")]
        [MaxLength(32,ErrorMessage ="كلمة المرور يجب أن لا تزيد عن 32 حرف وأرقام")]
        public string? Password { get; set; }

        [JsonIgnore]
        public AppUser AppUser
            => new AppUser
            {
                Email = Email,
                UserName = UserName,
                FirstName = FirstName,
                LastName = LastName,
                IsActive = true,
                Password = Password,
                PhoneNumber = PhoneNumber
            };
    }
}
