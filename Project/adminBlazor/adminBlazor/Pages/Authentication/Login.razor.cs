using adminBlazor.Models;
using adminBlazor.Services;
using Microsoft.AspNetCore.Components;

namespace adminBlazor.Pages.Authentication
{
    public partial class Login
    {
        [Inject]
        public CustomStateProvider AuthStateProvider { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        private string error { get; set; }
        private LoginRequest loginRequest { get; set; } = new LoginRequest();

        private async Task OnSubmit()
        {
            error = null;
            try
            {
                await AuthStateProvider.Login(loginRequest);
                NavigationManager.NavigateTo("");
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
        }
    }
}
