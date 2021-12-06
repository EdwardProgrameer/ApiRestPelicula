using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestPelicula.helper
{
    public class HelpJwt
    {
        private readonly byte[] secret;
        public HelpJwt(string secretKey)
        {
            this.secret = Encoding.ASCII.GetBytes(secretKey);
        }
        public string CreateToken(string username)
        {
            var claims = new ClaimsIdentity();
            claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, username));
            var tokenDescription = new SecurityTokenDescriptor()
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(this.secret), SecurityAlgorithms.HmacSha256Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var createdToken = tokenHandler.CreateToken(tokenDescription);
            return tokenHandler.WriteToken(createdToken);

        }
    }
}
