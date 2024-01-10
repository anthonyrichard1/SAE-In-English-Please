using adminBlazor.Factories;
using adminBlazor.Models;
using Blazored.LocalStorage;
using Blazorise.Extensions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;

namespace adminBlazor.Services
{
    public class DataLocalService : IDataService
    {
            private readonly HttpClient _http;
            private readonly ILocalStorageService _localStorage;
            private readonly NavigationManager _navigationManager;
            private readonly IWebHostEnvironment _webHostEnvironment;

            public DataLocalService(
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
            public DataLocalService(ILocalStorageService localStorage)
        {
            _localStorage = localStorage; // Assure-toi que LocalStorage est initialisé correctement ici
        }

        public async Task Add(UserModel model)
        {
            var currentData = await _localStorage.GetItemAsync<List<User>>("data");

            // Simulate the Id
            model.Id = currentData.Max(s => s.Id) + 1;

            // Add the item to the current data
            currentData.Add(UserFactory.Create(model));

            // Save the image
 

            // Save the data
            await _localStorage.SetItemAsync("data", currentData);


        }

        public Task<int> Count()
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetById(int id)
        {

            var currentData = await _localStorage.GetItemAsync<List<User>>("data");

            var user = currentData.FirstOrDefault(w => w.Id == id);

            if (user == null)
            {
                throw new Exception($"Unable to found the item with ID: {id}");
            }

            return user;
        }

        public Task<List<User>> List(int currentPage, int pageSize)
        {
            throw new NotImplementedException();
        }

        public async Task Update(int id, UserModel model)
        {
            // Get the current data
            var currentData = await _localStorage.GetItemAsync<List<User>>("data");

            var user = currentData.FirstOrDefault(w => w.Id == id);

            if (user == null)
            {
                throw new Exception($"Unable to found the item with ID: {id}");
            }

            // Save the image
       //
 
            UserFactory.Update(user, model);

            // Modify the content of the item


            // Save the data
            await _localStorage.SetItemAsync("data", currentData);
        }

        public async Task Delete(int id)
        {
            // Get the current data
            var currentData = await _localStorage.GetItemAsync<List<User>>("data");

            // Get the item int the list
            var item = currentData.FirstOrDefault(w => w.Id == id);

            // Delete item in
            currentData.Remove(item);

            // Delete the image


            // Save the data
            await _localStorage.SetItemAsync("data", currentData);
        }
    }
}
