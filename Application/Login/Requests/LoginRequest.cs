using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Login.Requests
{
    public sealed class LoginRequest
    {
        [StringLength(16), Required]
        public string Username { get; set; }

        [StringLength(16), Required]
        public string Password { get; set; }

        [Required]
        public bool RememberMe { get; set; }
    }
}
