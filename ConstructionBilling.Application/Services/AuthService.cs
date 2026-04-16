using ConstructionBilling.Application.Common;
using ConstructionBilling.Infrastructure.Interfaces;
using Microsoft.Extensions.Configuration;
using ConstructionBilling.Application.Dtos;
using System.Security.Claims;
using ConstructionBilling.Application.Interfaces;

namespace ConstructionBilling.Application.Services
{
    /// <summary>
    /// Authentication service implementation.
    /// </summary>
    public class AuthService : IAuthService
    {
        private readonly ILabourRepository _labourRepository;
        private readonly IConfiguration _configuration;
        public AuthService(ILabourRepository labourRepository, IConfiguration configuration)
        {
            _labourRepository = labourRepository;
            _configuration = configuration;
        }

        /// <inheritdoc/>
        public async Task<TokenDto> LoginAsync(string username, string password)
        {
            var users = await _labourRepository.GetLaboursDetails(null);
            //var oldEnPassword = BCrypt.Net.BCrypt.HashPassword(password);
            var user = users
                .Where(x => x.UserName == username)
                .FirstOrDefault();
            if (user == null)
            {
                throw new Exception("The username not match.");
            }

            if (string.IsNullOrEmpty(user.Password))
            {
                throw new Exception("Please reset your password and then continue to login.");
            }
            if (BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                var jwtService = new JwtService(_configuration["JWTSettings:SecretKey"] ?? string.Empty,
                    _configuration["JWTSettings:Issuer"] ?? string.Empty, _configuration["JWTSettings:Audience"] ?? string.Empty);
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, Convert.ToString(user.Name)),
                    new Claim(ClaimTypes.Role, Convert.ToString(user.RoleName)),
                    new Claim("RoleId", user.RoleId.ToString()),
                    new Claim("UserId", user.Id.ToString())
                };


                // Set token expiration time
                var expires = DateTime.UtcNow.AddDays(1);
                string fullName = user.Name ;
                // Generate the token
                var token = jwtService.GenerateToken(claims, expires);
                return new TokenDto() { Token = token, ExpiresAt = expires, RoleId = user.RoleId,RoleName=user.RoleName, Username = fullName ,UserId=user.Id};
            }
            else
            {
                throw new Exception("The username or password does not match.");
            }
        }

        /// <inheritdoc/>
        public async Task<bool> ResetPasswordAsync(string username, string password)
        {
            var users = await _labourRepository.GetLaboursDetails(null);
            var newEnPassword = BCrypt.Net.BCrypt.HashPassword(password);

            var user = users
               .Where(x => x.UserName == username && x.Password == newEnPassword)
               .FirstOrDefault();
            if (user == null)
            {
                throw new Exception("The username not match.");
            }
            var newPassword = BCrypt.Net.BCrypt.HashPassword(password);

            await _labourRepository.ResetPasswordAsync(user.UserId,username, newPassword, user.Name);
            return true;
        }
        /// <inheritdoc/>
        public async Task<bool> ChangePasswordAsync(string username, string oldPassword, string newPassword)
        {
            var users = await _labourRepository.GetLaboursDetails(null);
            var newEnPassword = BCrypt.Net.BCrypt.HashPassword(newPassword);
            var oldEnPassword = BCrypt.Net.BCrypt.HashPassword(oldPassword);

            var user = users
               .Where(x => x.UserName == username && x.Password == oldEnPassword)
               .FirstOrDefault();
            if (user == null)
            {
                throw new Exception("The username does not match.");
            }
            else if (! BCrypt.Net.BCrypt.Verify(oldEnPassword, user.Password))
            {
                throw new Exception("The password does not match.");
            }
           
            else
            { 
                 await _labourRepository.ResetPasswordAsync(user.UserId,username, newEnPassword,user.Name);
                return true;
            }
        }

       
    }
}
