using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace WebApiJwt.Models
{
    public class CreateToken
    {
        public string TokenCreate()
        {
            var bytes = Encoding.UTF8.GetBytes("aspnetcoreapiapiaspnetcoreapiapi");
            SymmetricSecurityKey key= new SymmetricSecurityKey(bytes);
            SigningCredentials signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            JwtSecurityToken token = new JwtSecurityToken(issuer: "https://localhost",
                audience: "https://localhost",
                notBefore:DateTime.Now,
                expires: DateTime.Now.AddMinutes(3),
                signingCredentials: signingCredentials
            );
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            return handler.WriteToken(token);
        }
    }
}
