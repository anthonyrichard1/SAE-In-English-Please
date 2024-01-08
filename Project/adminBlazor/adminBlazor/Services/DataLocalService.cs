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

        public required ILocalStorageService LocalStorage { get; set; }

        [Inject]
        public required IWebHostEnvironment WebHostEnvironment { get; set; }

        public DataLocalService dataLocalService => throw new NotImplementedException();

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
            // Get the current data
            var currentData = await LocalStorage.GetItemAsync<List<User>>("data");

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

        public async Task Update(int id, User model)
        {
            // Get the current data
            var currentData = await LocalStorage.GetItemAsync<List<User>>("data");

            var user = currentData.FirstOrDefault(w => w.Id == id);

            if (user == null)
            {
                throw new Exception($"Unable to found the item with ID: {id}");
            }

            // Save the image
            var imagePathInfo = new DirectoryInfo($"{WebHostEnvironment.WebRootPath}/images");

            // Check if the folder "images" exist
            if (!imagePathInfo.Exists)
            {
                imagePathInfo.Create();
            }

            // Delete the previous image
            if (user.Name != model.Name)
            {
                var oldFileName = new FileInfo($"{imagePathInfo}/{user.Name}.png");

                if (oldFileName.Exists)
                {
                    File.Delete(oldFileName.FullName);
                }
            }

            // Determine the image name
            var fileName = new FileInfo($"{imagePathInfo}/{model.Name}.png");

            // Write the file content
            //await File.WriteAllBytesAsync(fileName.FullName, model.Image);
            UserFactory.Update(user, model);

            // Modify the content of the item
            user.Nickname = model.Nickname;
            user.Name = model.Name;
            user.Surname = model.Surname;
            user.Roles = model.Roles;
            user.Group = model.Group;
            user.Email = model.Email;
            user.ExtraTime = model.ExtraTime;
            user.Password = model.Password;
            user.Image = model.Image;

            // Save the data
            await LocalStorage.SetItemAsync("data", currentData);
        }
    }
}
