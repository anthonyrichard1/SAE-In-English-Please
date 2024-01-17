using adminBlazor.Components;
using adminBlazor.Factories;
using adminBlazor.Models;
using System.Reflection.Metadata.Ecma335;

namespace adminBlazor.Services
{
    public class DataApiService : IDataService
    {
        private readonly HttpClient _http;

        public DataApiService(
           HttpClient http)
        {
            _http = http;
        }

        public async Task Add(UserModel model)
        {
            // Get the item
            var item = UserFactory.Create(model);

            // Save the data
             await _http.PostAsJsonAsync("https://localhost:7234/api/User/", item);
        }

        public async Task<int> Count()
        {
            return await _http.GetFromJsonAsync<int>("https://localhost:7234/api/User/count");
        }

        public async Task<List<User>> List(int currentPage, int pageSize)
        {
            return await _http.GetFromJsonAsync<List<User>>($"https://localhost:7234/api/User/?currentPage={currentPage}&pageSize={pageSize}");
        }

        public async Task<User> GetById(int id)
        {
                return await _http.GetFromJsonAsync<User>($"https://localhost:7234/api/User/{id}");
        }

        public async Task Update(int id, UserModel model)
        {
            // Get the item
            var item = UserFactory.Create(model);

             await _http.PutAsJsonAsync($"https://localhost:7234/api/User/{id}", item);
        }

        public async Task Delete(int id)
        {
            await _http.DeleteAsync($"https://localhost:7234/api/User/{id}");
        }

         public async Task<List<CraftingRecipe>> GetRecipes()
         {
            return await _http.GetFromJsonAsync<List<CraftingRecipe>>("https://localhost:7234/api/User/recipe");
         }
    }
}
