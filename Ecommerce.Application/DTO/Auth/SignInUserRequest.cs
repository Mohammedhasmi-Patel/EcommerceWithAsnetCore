using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.DTO.Auth
{
    public class SignInUserRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(8,ErrorMessage ="Password must be atleast 8 characters")]
        public string Password { get; set; }

    }
}
