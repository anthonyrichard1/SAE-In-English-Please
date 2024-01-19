using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Threading.Tasks;
using adminBlazor.Services;

namespace adminBlazor.Shared
{
    public partial class MainLayout
    {
        [Inject]
        public CustomStateProvider AuthStateProvider { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [CascadingParameter]
        private Task<AuthenticationState> AuthenticationState { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            if (!(await AuthenticationState).User.Identity.IsAuthenticated)
            {
                NavigationManager.NavigateTo("/login");
            }
        }

        private async Task LogoutClick()
        {
            await AuthStateProvider.Logout();
            NavigationManager.NavigateTo("/login");
        }
    }
}
