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


        /*        protected override async Task OnAfterRenderAsync(bool firstRender)
                {
                    // Do not treat this action if is not the first render
                    if (!firstRender)
                    {
                        return;
                    }

                    var currentData = await LocalStorage.GetItemAsync<User[]>("data");

                    // Check if data exist in the local storage
                    if (currentData == null)
                    {
                        // this code add in the local storage the fake data (we load the data sync for initialize the data before load the OnReadData method)
                        var originalData = Http.GetFromJsonAsync<User[]>($"{NavigationManager.BaseUri}user.json").Result;
                        await LocalStorage.SetItemAsync("data", originalData);
                    }
                }
        */

        private async Task OnReadData(DataGridReadDataEventArgs<User> e)
        {
            if (e.CancellationToken.IsCancellationRequested)
            {
                return;
            }

            // When you use a real API, we use this follow code
            //var response = await Http.GetJsonAsync<Data[]>( $"http://my-api/api/data?page={e.Page}&pageSize={e.PageSize}" );
            //var response = (await LocalStorage.GetItemAsync<User[]>("data")).Skip((e.Page - 1) * e.PageSize).Take(e.PageSize).ToList();

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

            await DataService.Delete(id);

            // Reload the page
            NavigationManager.NavigateTo("list", true);
        }
    }

}