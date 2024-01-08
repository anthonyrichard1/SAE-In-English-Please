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

        public Task Add(User model)
        {
            throw new NotImplementedException();
        }

        public Task<int> Count()
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetById(int id)
        {

            //var currentData = await LocalStorage.GetItemAsync<User[]>("user.json");
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
       var imagePathInfo = new DirectoryInfo($"{_webHostEnvironment.WebRootPath}/images");

            // Check if the folder "images" exist
      //      if (!imagePathInfo.Exists)
            {
       //         imagePathInfo.Create();
            }

            // Delete the previous image
            if (user.Name != model.Name)
            {
         //       var oldFileName = new FileInfo($"{imagePathInfo}/{user.Name}.png");

           //     if (oldFileName.Exists)
                {
             //       File.Delete(oldFileName.FullName);
                }
            }

            // Determine the image name
            var fileName = new FileInfo($"{imagePathInfo}/{model.Name}.png");

            // Write the file content
           // await File.WriteAllBytesAsync(fileName.FullName, model.Image);
            UserFactory.Update(user, model);

            // Modify the content of the item


            // Save the data
            await _localStorage.SetItemAsync("data", currentData);
        }
    }
}
