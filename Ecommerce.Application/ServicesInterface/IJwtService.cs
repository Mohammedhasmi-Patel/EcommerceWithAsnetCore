using Ecommerce.Application.DTO.Common;
using Ecommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.ServicesInterface
{
    public interface IJwtService
    {
        public JwtTokenResponse GenerateJwtToken(ApplicationUser applicationUser);
    }
}
