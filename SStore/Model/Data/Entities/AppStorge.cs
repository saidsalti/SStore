using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SStore.Model.Data.Entities
{
    [Table(nameof(AppStorge))]
    public class AppStorge : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string? FileName { get; set; }
        public string? FileType { get; set; }
        public long? FileSize { get; set; }

    }
}



