using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CommentApp.Service.Helpers.AuthenticationManager
{
    public class JWTAuthenticationManager:IJWTAuthenticationManager
    {
        #region Members
        private IConfiguration config;
        #endregion

        #region Constructor
        public JWTAuthenticationManager(IConfiguration _config)
        {
            this.config = _config;
        }
        #endregion


        /// <summary>
        /// GenerateJSONWebToken Method is used to generate JWT token 
        /// </summary>
        /// /// <param name="userId"></param>
        /// <returns>JWT token</returns>
        public string GenerateJSONWebToken(Guid userId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(config["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("UserId", userId.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
