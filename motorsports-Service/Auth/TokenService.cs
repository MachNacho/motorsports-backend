using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using motorsports_Domain.Entities;
using motorsports_Service.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace motorsports_Service.Auth
{
    public class TokenService : ITokenService
    {

        private readonly IConfiguration _config;
        private readonly SymmetricSecurityKey _key;

        public TokenService(IConfiguration config)
        {
            _config = config;
            var signingKey = _config["JWT:SigningKey"] ?? throw new ArgumentNullException("JWT:SigningKey", "JWT signing key must be configured"); ;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signingKey));
        }
        public string CreateToken(UserEntity user, IList<string>? roles)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            // Build the claims collection for the JWT payload
            var Claims = new List<Claim> {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                new Claim(JwtRegisteredClaimNames.Name, user.NormalizedUserName),
                new Claim(JwtRegisteredClaimNames.Email,user.NormalizedEmail),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            // Add role claims
            if (roles != null && roles.Any())
            {
                foreach (var role in roles)
                {
                    Claims.Add(new Claim(ClaimTypes.Role, role));
                }
            }

            //Configure signing credentials using HMAC SHA-512 algorithm
            var signingCredentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            // Define the token descriptor with all necessary properties
            var TokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(Claims),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = signingCredentials,
                Issuer = _config["JWT:Issuer"],
                Audience = _config["JWT:Audience"]
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(TokenDescription);

            return tokenHandler.WriteToken(token);
        }
    }
}
