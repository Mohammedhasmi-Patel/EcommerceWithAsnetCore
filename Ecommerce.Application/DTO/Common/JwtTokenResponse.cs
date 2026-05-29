using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.DTO.Common
{
    public class JwtTokenResponse
    {
        public string Token { get; set; } = string.Empty;
        public DateTime TokenExpiration { get; set; } 
    }
}
