using Common.Logger;
using Common.Model.Settings;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Common.ApiService
{
    public class TokenCreationHandler : ITokenCreationHandler
    {
        private ILoggingService _logger;
        private readonly IOptionsMonitor<ConsumerServiceSettings> _consumerServiceSettings;

        public TokenCreationHandler(ILoggingService logger, IOptionsMonitor<ConsumerServiceSettings> ConsumerServiceSettings)
        {
            _logger = logger;
            _consumerServiceSettings = ConsumerServiceSettings;
            _logger.LogInformation($"TokenCreationHandler is Configured with Issuer: { _consumerServiceSettings.CurrentValue.Issuer } ");
        }

        public string CreateToken()
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Role, "role")
            });

            var securityKey = new SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(_consumerServiceSettings.CurrentValue.JWTEncryptionKey));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            //Set issued at date
            DateTime issuedAt = DateTime.UtcNow;
            //set the time when it expires
            var minutes = _consumerServiceSettings.CurrentValue.ExpireToken;
            DateTime expires = issuedAt.AddMinutes(Convert.ToInt32(minutes));

            //create the jwt
            var token = (JwtSecurityToken)tokenHandler.CreateJwtSecurityToken(
                issuer: _consumerServiceSettings.CurrentValue.Issuer,
                audience: _consumerServiceSettings.CurrentValue.Audience,
                subject: claimsIdentity,
                notBefore: DateTime.UtcNow,
                expires: expires,
                signingCredentials: signingCredentials);

            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }
    }
}