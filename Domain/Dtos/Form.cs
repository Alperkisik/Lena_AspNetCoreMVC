using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos
{
    public sealed class Form
    {
        public Form()
        {
            Fields = new List<FormField>();
        }

        [Key]
        public int Id { get; set; }

        [Required, StringLength(50)]
        public required string Name { get; set; }

        [StringLength(50)]
        public string? Description { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }

        public int CreatedBy { get; set; }

        public List<FormField> Fields { get; set; }
    }
}