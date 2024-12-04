using FitnessWorkoutTracker.Domain.Entities.Users;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace FitnessWorkoutTracker.Application.Utilities
{
    public class TokenUtils
    {
        private readonly IConfiguration _configuration;
        private readonly string? _jwtSecretKey;
        private readonly string? _jwtIssuer;
        private readonly string? _jwtAudience;
        private readonly short _tokenExpirationMinutes;


        public TokenUtils(IConfiguration configuration)
        {
            _configuration = configuration;
            _jwtSecretKey = _configuration["Jwt:Key"];
            _jwtIssuer = _configuration["Jwt:Issuer"];
            _jwtAudience = _configuration["Jwt:Audience"];
            _tokenExpirationMinutes = short.Parse(_configuration["Jwt:ExpirationMinutes"]);
        }

        public (string token, DateTime expireDate) GenerateAccessToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSecretKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new Claim[]
            {
                new Claim("id",user.Id.ToString())
            };

            var tokenExpire = DateTime.UtcNow.AddMinutes(_tokenExpirationMinutes);
            var tokenDetails = new JwtSecurityToken(issuer: _jwtIssuer,
                audience: _jwtAudience,
                claims: claims,
                expires: tokenExpire,
                signingCredentials: credentials);

            var token = new JwtSecurityTokenHandler().WriteToken(tokenDetails);
            return (token, tokenExpire);
        }

        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using var rnd = RandomNumberGenerator.Create();
            rnd.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }
        public JwtSecurityToken? ValidateJwtToken(string token)
        {
            if (token == null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var PrivateKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSecretKey));
            var jwtToken = new JwtSecurityToken();

            try
            {
                var claimPrincipal = tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = PrivateKey,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken securityToken);
                jwtToken = (JwtSecurityToken)securityToken;
                return jwtToken;
            }
            catch (SecurityTokenException ex)
            {
                return null;
            }
        }
        public JwtSecurityToken? ReadJwtToken(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadToken(token) as JwtSecurityToken;
            return jwtToken;
        }
    }
}
