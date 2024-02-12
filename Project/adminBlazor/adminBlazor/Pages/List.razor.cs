using Blazored.LocalStorage;
using Blazorise.DataGrid;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http.Features;
using adminBlazor.Models;
using System.Net.Http;
using System.Net.Http.Json;
using adminBlazor.Services;
using Blazored.Modal.Services;
using Blazored.Modal;
using adminBlazor.Modals;
using Blazorise;

namespace adminBlazor.Pages
{
    public partial class List
    {
        private List<User> _users;

        private int totalUser;

        [Inject]
        public HttpClient Http { get; set; }

        [Inject]
        public ILocalStorageService LocalStorage { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [CascadingParameter]
        public Blazored.Modal.Services.IModalService Modal { get; set; }

        [Inject]
        public IDataService DataService { get; set; }

        [Inject]
        public IWebHostEnvironment WebHostEnvironment { get; set; }



        private async Task OnReadData(DataGridReadDataEventArgs<User> e)
        {
            if (e.CancellationToken.IsCancellationRequested)
            {
                return;
            }

            if (!e.CancellationToken.IsCancellationRequested)
            {
                _users = await DataService.List(e.Page, e.PageSize);
                totalUser = await DataService.Count();// an actual data for the current page
            }
        }

        private async void OnDelete(int id)
        {
            var parameters = new ModalParameters();
            parameters.Add("Id", id);

            var modal = Modal.Show<UserDeleteConfirmation>("Delete Confirmation", parameters);
            var result = await modal.Result;

           if (result.Cancelled)
            {
                return;
            }

            if (DataService != null)
            {
                await DataService.Delete(id);
            }
            // Reload the page
            NavigationManager.NavigateTo("list", true);
        }
    }

}