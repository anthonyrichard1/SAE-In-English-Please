
namespace adminBlazor.Pages.Authentication
{
    using adminBlazor.Models;
    using Microsoft.AspNetCore.Components;
    using System;
    using System.Threading.Tasks;
    using adminBlazor.Services;

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