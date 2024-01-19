using adminBlazor.Models;
using adminBlazor.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace adminBlazor.Pages.Authentication
{


    public partial class Register
    {
        [Inject]
        public CustomStateProvider AuthStateProvider { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        private string error { get; set; }
        private RegisterRequest registerRequest { get; set; } = new RegisterRequest();

        private async Task OnSubmit()
        {
            error = null;
            try
            {
                await AuthStateProvider.Register(registerRequest);
                NavigationManager.NavigateTo("");
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
        }
    }
}