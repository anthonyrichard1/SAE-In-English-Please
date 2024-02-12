namespace adminBlazor.Services
{
    using adminBlazor.Models;

    public interface IAuthService
    {
        CurrentUser GetUser(string userName);

        void Login(LoginRequest loginRequest);

        void Register(RegisterRequest registerRequest);
    }
}