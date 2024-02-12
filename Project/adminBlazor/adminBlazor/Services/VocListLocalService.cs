using adminBlazor.Factories;
using adminBlazor.Models;
using Blazored.LocalStorage;
using Blazorise.Extensions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;

namespace adminBlazor.Services
{
    public class VocListLocalService : IVocListService
    {
        private readonly HttpClient _http;
        private readonly ILocalStorageService _localStorage;
        private readonly NavigationManager _navigationManager;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public VocListLocalService(
            ILocalStorageService localStorage,
            HttpClient http,
            IWebHostEnvironment webHostEnvironment,
            NavigationManager navigationManager)
        {
            _localStorage = localStorage;
            _http = http;
            _webHostEnvironment = webHostEnvironment;
            _navigationManager = navigationManager;
        }


        public async Task Add(VocabularyListModel model)
        {
            var currentList = await _localStorage.GetItemAsync<List<VocabularyList>>("voc");

            model.Id = currentList.Max(s => s.Id) + 1;

            currentList.Add(VocListFactory.Create(model));

            await _localStorage.SetItemAsync("voc", currentList);
        }

        public async Task<int> Count()
        {
            var currentList = await _localStorage.GetItemAsync<VocabularyList[]>("voc");

            // Check if data exist in the local storage
            if (currentList == null)
            {
                // this code add in the local storage the fake data
                var originalList = await _http.GetFromJsonAsync<VocabularyList[]>($"{_navigationManager.BaseUri}voc.json");
                await _localStorage.SetItemAsync("voc", originalList);
            }

            return (await _localStorage.GetItemAsync<VocabularyList[]>("voc")).Length;
        }

        public async Task<List<VocabularyList>> List(int currentPage, int pageSize)
        {
            var currentList = await _localStorage.GetItemAsync<VocabularyList[]>("voc");

            // Check if data exist in the local storage
            if (currentList == null)
            {
                // this code add in the local storage the fake data
                var originalData = await _http.GetFromJsonAsync<VocabularyList[]>($"{_navigationManager.BaseUri}voc.json");
                await _localStorage.SetItemAsync("voc", originalData);
            }

            return (await _localStorage.GetItemAsync<VocabularyList[]>("voc")).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

        }

        public async Task<VocabularyList> GetById(int id)
        {
            var currentLists = await _localStorage.GetItemAsync<List<VocabularyList>>("voc");

            var list = currentLists.FirstOrDefault(w => w.Id == id);

            if (list == null)
            {
                throw new Exception($"Unable to found the item with ID: {id}");
            }

            return list;
        }

        public async Task Update(int id, VocabularyListModel model)
        {
            // Get the current data
            var currentList = await _localStorage.GetItemAsync<List<VocabularyList>>("voc");

            var voc = currentList.FirstOrDefault(w => w.Id == id);

            if (voc == null)
            {
                throw new Exception($"Unable to found the item with ID: {id}");
            }

            // Save the image
            //

            VocListFactory.Update(voc, model);

            // Modify the content of the item


            // Save the data
            await _localStorage.SetItemAsync("voc", currentList);
        }

        public async Task Delete(int id)
        {
            // Get the current data
            var currentList = await _localStorage.GetItemAsync<List<VocabularyList>>("voc");

            // Get the item int the list
            var voc = currentList.FirstOrDefault(w => w.Id == id);

            // Delete item in
            currentList.Remove(voc);

            // Delete the image


            // Save the data
            await _localStorage.SetItemAsync("voc", currentList);
        }
    }
}
