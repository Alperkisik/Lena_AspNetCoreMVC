using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos
{
    public sealed class FormField
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public bool Required { get; set; }

        [Required,StringLength(50)]
        public required string Name { get; set; }

        [Required, StringLength(50)]
        public required string DataType { get; set; }

        [ForeignKey(nameof(Form))]
        public int FormId { get; set; }
    }
}
