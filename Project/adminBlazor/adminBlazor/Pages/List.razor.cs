using adminBlazor.Models;
using Blazored.LocalStorage;
using Blazorise.DataGrid;
using Microsoft.AspNetCore.Components;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace adminBlazor.Pages
{
    public partial class List
    {
        private User[] users;
        private int totalUser;

        [Inject]
        public HttpClient Http { get; set; }

        [Inject]
        public ILocalStorageService LocalStorage { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            // Do not treat this action if it is not the first render
            if (!firstRender)
            {
                return;
            }

            var currentData = await LocalStorage.GetItemAsync<User[]>("data");

            // Check if data exist in the local storage
            if (currentData == null)
            {
                // This code adds fake data to local storage (loading data synchronously to initialize before the OnReadData method)
                var originalData = await Http.GetFromJsonAsync<User[]>($"{NavigationManager.BaseUri}fake-data.json");
                await LocalStorage.SetItemAsync("data", originalData);
            }
        }

        private async Task OnReadData(DataGridReadDataEventArgs<User> e)
        {
            if (e.CancellationToken.IsCancellationRequested)
            {
                return;
            }

            // When you use a real API, you use the following code
            // var response = await Http.GetJsonAsync<User[]>( $"http://my-api/api/data?page={e.Page}&pageSize={e.PageSize}" );
            var response = (await LocalStorage.GetItemAsync<User[]>("data")).Skip((e.Page - 1) * e.PageSize).Take(e.PageSize).ToList();

            if (!e.CancellationToken.IsCancellationRequested)
            {
                totalUser = (await LocalStorage.GetItemAsync<User[]>("data")).Length;
                users = response.ToArray(); // actual data for the current page
            }
        }
    }
}
