using adminBlazor.Models;

namespace adminBlazor.Services
{
    public interface IAuthService
    {
        CurrentUser GetUser(string userName);

        void Login(LoginRequest loginRequest);

        void Register(RegisterRequest registerRequest);
    }
}
