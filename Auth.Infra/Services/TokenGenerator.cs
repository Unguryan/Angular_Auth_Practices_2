using Auth.App.Services;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Auth.Infra.Services
{
    public class TokenGenerator : ITokenGenerator
    {
        public Task<string> GenerateTokenAsync(string name, string surname, string email, string phone, bool longExpired = false)
        {
            var mySecret = "TestSecretKey-TestSecretKey-TestSecretKey";
            var mySecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(mySecret));

            var myIssuer = "http://localhost:5000/";

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, name),
                    new Claim(ClaimTypes.Surname, surname),
                    new Claim(ClaimTypes.Email, email),
                    new Claim("phone", phone),
                }),

                Expires = longExpired ? DateTime.UtcNow.AddDays(7) : DateTime.UtcNow.AddDays(1),
                //Expires = DateTime.UtcNow.AddMinutes(1),
                Issuer = myIssuer,
                SigningCredentials = new SigningCredentials(mySecurityKey, SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return Task.FromResult(tokenHandler.WriteToken(token));
        }
    }
}
