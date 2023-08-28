using API.Models;
using API.Services;
using FluentAssertions;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace DFCTest.Services
{
    public class TokenServiceTests
    {
        private AppSettings _appSettings => new()
        {
            Secret = "9B)(/&%$BAD620#$%&/674AF23F356D",
            ExpiresInHours = 5,
            Issuer = "anna_api",
            Audience = "anna_client"
        };

        private async Task<string> getTokenService()
        {
            var options = Options.Create(_appSettings);
            var tokenService = new TokenService(options);

            Login login = new("anna", "test");
            return await tokenService.GenerateToken(login);
        }

        [Fact]
        public async void TokenMustBeJWTFormat()
        {
            var token = await getTokenService();
            JwtSecurityTokenHandler handler = new();
            bool result = false;
            try
            {
                handler.ReadJwtToken(token);
                result = true;
            }
            catch (Exception)
            {
            }

            result.Should().BeTrue();
        }

        [Fact]
        public async void TokenMustContainExpireTimeIssuerAudience()
        {
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            TokenValidationParameters validate = new()
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidIssuer = _appSettings.Issuer,
                ValidAudience = _appSettings.Audience,
                RequireExpirationTime = true,
                ClockSkew = TimeSpan.Zero
            };
            var token = await getTokenService();
            JwtSecurityTokenHandler handler = new();
            SecurityToken validatedToken;
            bool result = false;
            try
            {
                handler.ValidateToken(token, validate, out validatedToken);
                result = true;
            }
            catch (Exception)
            {
            }

            result.Should().BeTrue();
        }
    }
}