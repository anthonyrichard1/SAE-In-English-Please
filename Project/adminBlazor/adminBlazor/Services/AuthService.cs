namespace adminBlazor.Services
{
    using adminBlazor.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;

    public class AuthService : IAuthService
    {
        private static readonly List<AppUser> CurrentUser;
        private readonly ILogger<AuthService> _logger;

        public AuthService(ILogger<AuthService> logger)
        {
            _logger = logger;
        }

        static AuthService()
        {
            CurrentUser = new List<AppUser>
            {
                new AppUser { UserName = "Admin", Password = "123456", Roles = new List<string> { "admin" } },
                new AppUser{ UserName ="Teacher1", Password = "123456", Roles = new List<string>{ "teacher" } }
            };
        }

        public CurrentUser GetUser(string userName)
        {
            var user = CurrentUser.FirstOrDefault(w => w.UserName == userName);

            if (user == null)
            {
                _logger.LogWarning("Authentication failed, field invalid.");
                throw new Exception("User name or password invalid !");
            }

            var claims = new List<Claim>();
            claims.AddRange(user.Roles.Select(s => new Claim(ClaimTypes.Role, s)));

            return new CurrentUser
            {
                IsAuthenticated = true,
                UserName = user.UserName,
                Claims = claims.ToDictionary(c => c.Type, c => c.Value)
            };
        }

        public void Login(LoginRequest loginRequest)
        {
            var user = CurrentUser.FirstOrDefault(w => w.UserName == loginRequest.UserName && w.Password == loginRequest.Password);

            if (user == null)
            {
                _logger.LogWarning("Authentication : login failed, field invalid.");
                throw new Exception("User name or password invalid !");
            }
            
            _logger.LogInformation("Authentication : login success.");
        }

        public void Register(RegisterRequest registerRequest)
        {
            CurrentUser.Add(new AppUser { UserName = registerRequest.UserName, Password = registerRequest.Password, Roles = new List<string> { "guest" } });
            _logger.LogInformation("Authentication : register success.");
        }
    }
}