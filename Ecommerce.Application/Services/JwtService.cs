using Ecommerce.Application.DTO.Common;
using Ecommerce.Application.ServicesInterface;
using Ecommerce.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Ecommerce.Application.Services
{
    public class JwtService : IJwtService
    {
        private readonly JwtConfiguration _jwtConfiguration;

        public JwtService(IOptions<JwtConfiguration> options)
        {
            _jwtConfiguration = options.Value;
        }
        public JwtTokenResponse GenerateJwtToken(ApplicationUser applicationUser)
        {
            // first create the claims which is type of array
            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,applicationUser.Id.ToString()), // unique id 
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()), // jwt unqiue id 
                new Claim(JwtRegisteredClaimNames.Iat,DateTime.UtcNow.ToString()), // generate token time
                new Claim(ClaimTypes.NameIdentifier,applicationUser.Email), // user email optional 
                                                                                  
            };

            // craete all the value which we have define inside the aplication json 
            var symmetricKey = new SymmetricSecurityKey( Encoding.UTF8.GetBytes(_jwtConfiguration.SecretKey));
            var issuer = _jwtConfiguration.Issuer;
            var audience = _jwtConfiguration.Audience;
            DateTime expiration = DateTime.UtcNow.AddMinutes(_jwtConfiguration.ExpirationInMinutes);

            // create signin creadetials along with security key & algorithm
            SigningCredentials signingCredentials = new SigningCredentials(symmetricKey,SecurityAlgorithms.HmacSha256);

            JwtSecurityToken tokenGenerator = new JwtSecurityToken(
                issuer,
                audience,
                claims,
                expires : expiration,
                signingCredentials : signingCredentials
             );

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            string token = tokenHandler.WriteToken(tokenGenerator);

            return new JwtTokenResponse()
            {
                Token = token,
                TokenExpiration = expiration
            };

        }
    }
}
