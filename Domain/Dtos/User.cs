using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50), Required]
        public string Username { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public DateTime CreatedAt { get; set; }

        [StringLength(16), Required]
        public string Password { get; set; }
    }
}
