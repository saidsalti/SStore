using Microsoft.EntityFrameworkCore;
using SStore.Model.Data.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SStore.Model.Data.Entities
{
    public class BaseEntity
    {

        public DateTime? Created { get; set; } = DateTime.Now;
        public int? CreatedBy { get; set; }
        public DateTime? ModifyDate { get; set; }
        public int? ModifyBy { get; set; }
    }
    [Table(nameof(AppUser))]
    [Index(nameof(Email), IsUnique = true)]
    [Index(nameof(UserName), IsUnique = true)]
    public class AppUser
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        [Required]
        public string? UserName { get; set; }
        [StringLength(50)]
        public string? Password { get; set; }
        [StringLength(500)]
        [Required]
        public string? Email { get; set; }
        [StringLength(50)]
        [Required]
        public string? FirstName { get; set; }
        [StringLength(50)]
        [Required]
        public string? LastName { get; set; }
        [StringLength(15)]
        public string? PhoneNumber { get; set; }
        public bool? IsActive { get; set; }

    }
}



