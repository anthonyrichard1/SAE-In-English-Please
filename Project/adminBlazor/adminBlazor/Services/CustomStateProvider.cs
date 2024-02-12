namespace adminBlazor.Services
{
    using adminBlazor.Models;
    using Microsoft.AspNetCore.Components.Authorization;
    using System;
    using System.Linq;
    using System.Net.Http;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Blazored.SessionStorage;


    public class CustomStateProvider : AuthenticationStateProvider
    {
        private readonly IAuthService _authService;
        private readonly ISessionStorageService _sessionStorage;
        private CurrentUser? _currentUser;

        public CustomStateProvider(IAuthService authService, ISessionStorageService sessionStorage)
        {
            this._authService = authService;
            this._sessionStorage = sessionStorage;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            await GetCurrentUser();
            var identity = new ClaimsIdentity();
            try
            {
                if (_currentUser?.IsAuthenticated == true)
                {
                    var claims = new[] { new Claim(ClaimTypes.Name, _currentUser.UserName) }
                        .Concat(_currentUser.Claims.Select(c => new Claim(c.Key, c.Value)));
                    identity = new ClaimsIdentity(claims, "Server authentication");
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("Request failed:" + ex);
            }

            return new AuthenticationState(new ClaimsPrincipal(identity));
        }

        public async Task Login(LoginRequest loginParameters)
        {
            _authService.Login(loginParameters);

            // No error - Login the user
            var user = _authService.GetUser(loginParameters.UserName);
            _currentUser = user;
            
            await _sessionStorage.SetItemAsync("currentUser", _currentUser);

            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        public async Task Logout()
        {
            await _sessionStorage.RemoveItemAsync("currentUser");
            _currentUser = null;
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        public async Task Register(RegisterRequest registerParameters)
        {
            _authService.Register(registerParameters);

            // No error - Login the user
            var user = _authService.GetUser(registerParameters.UserName);
            _currentUser = user;

            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        private async Task GetCurrentUser()
        {
            _currentUser = await _sessionStorage.GetItemAsync<CurrentUser>("currentUser");
            if (_currentUser != null && _currentUser.IsAuthenticated){} //user is authenticate
            else { _currentUser = new CurrentUser(); }
        }
    }
}