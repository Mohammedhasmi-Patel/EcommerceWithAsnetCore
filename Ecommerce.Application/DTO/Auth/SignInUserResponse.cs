using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.DTO.Auth
{
    public class SignInUserResponse
    {
        public string Email { get; set; }
        public string FirstName { get; set; }

        public string? Avatar { get; set; }
        public string Token { get; set; }
        public DateTime ExpirationToken { get; set; }


    }
}
