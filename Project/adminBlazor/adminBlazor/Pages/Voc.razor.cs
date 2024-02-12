using adminBlazor.Modals;
using adminBlazor.Models;
using adminBlazor.Services;
using Blazored.LocalStorage;
using Blazored.Modal;
using Blazored.Modal.Services;
using Blazorise.DataGrid;
using Microsoft.AspNetCore.Components;

namespace adminBlazor.Pages
{
    public partial class Voc
    {
        private List<VocabularyList> _vocList;

        private int totalVocList;

        [Inject]
        public HttpClient Http { get; set; }

        [Inject]
        public ILocalStorageService LocalStorage { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [CascadingParameter]
        public IModalService Modal { get; set; }

        [Inject]
        public IVocListService VocListService { get; set; }


        /*protected async Task OnAfterRenderAsync(bool firstRender)
        {
            // Do not treat this action if is not the first render
            if (firstRender)
            {
                return;
            }

            var currentData = await LocalStorage.GetItemAsync<VocabularyList[]>("voc");

            // Check if data exist in the local storage
            if (currentData == null)
            {
                // this code add in the local storage the fake data (we load the data sync for initialize the data before load the OnReadData method)
                var originalData = Http.GetFromJsonAsync<VocabularyList[]>($"{NavigationManager.BaseUri}voc.json").Result;
                await LocalStorage.SetItemAsync("voc", originalData);
            }
        }*/

        private async Task OnReadData(DataGridReadDataEventArgs<VocabularyList> e)
        {
            if (e.CancellationToken.IsCancellationRequested)
            {
                return;
            }

            // When you use a real API, we use this follow code
            //var response = await Http.GetJsonAsync<Data[]>( $"http://my-api/api/data?page={e.Page}&pageSize={e.PageSize}" );
            //var response = (await LocalStorage.GetItemAsync<VocabularyList[]>("voc")).Skip((e.Page - 1) * e.PageSize).Take(e.PageSize).ToList();

            if (!e.CancellationToken.IsCancellationRequested)
            {
                _vocList = await VocListService.List(e.Page, e.PageSize);
                totalVocList = await VocListService.Count();// an actual data for the current page
            }
        }

        private async void OnDelete(int id)
        {
            var parameters = new ModalParameters();
            parameters.Add("Id", id);

            var modal = Modal.Show<VocListDeleteConfirmation>("Delete Confirmation", parameters);
            var result = await modal.Result;

            if (result.Cancelled)
            {
                return;
            }

            await VocListService.Delete(id);

            // Reload the page
            NavigationManager.NavigateTo("voc", true);
        }
    }
}