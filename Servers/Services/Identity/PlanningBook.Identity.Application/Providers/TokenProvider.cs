using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using PlanningBook.Identity.Infrastructure.Entities;

namespace PlanningBook.Identity.Application.Providers
{
    public sealed class TokenProvider : ITokenProvider
    {
        private readonly IConfiguration _configuration;

        public TokenProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(Account account)
        {
            string secretKey = _configuration["Jwt:Secret"]!;
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                [
                    new Claim("id", account.Id.ToString()),
                    //new Claim(JwtRegisteredClaimNames.PhoneNumber, account.PhoneNumber.ToString())
                ]),
                // Note: configurateion.GetValue<> from .net core 8 need to install Microsoft.Extensions.Configuration.Binder
                Expires = DateTime.UtcNow.AddMinutes(_configuration.GetValue<int>("Jwt:ExpirationInMinutes")),
                SigningCredentials = credentials,
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"]
            };

            var handler = new JsonWebTokenHandler();

            string token = handler.CreateToken(tokenDescriptor);

            return token;
        }
    }
}
