using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components;
using adminBlazor.Models;

namespace adminBlazor.Pages
{
    public partial class Add
    {
        [Inject]
        public ILocalStorageService LocalStorage { get; set; }

        [Inject]
        public IWebHostEnvironment WebHostEnvironment { get; set; }


        /// <summary>
        /// The default enchant categories.
        /// </summary>
        private List<string> roles = new List<string>() { "admin","teacher","student" };


        /// <summary>
        /// The current item model
        /// </summary>
        private User user = new User()
        {
            Roles = new string[] { "admin", "teacher", "student" }
    };

        private async void HandleValidSubmit()
        {
            // Get the current data
            var currentData = await LocalStorage.GetItemAsync<List<User>>("data");

            // Simulate the Id
            user.Id = currentData.Max(s => s.Id) + 1;

            // Add the item to the current data
            currentData.Add(new User
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                Nickname = user.Nickname,
                ExtraTime = user.ExtraTime,
                Image = user.Image,
                Group = user.Group,
                Password = user.Password,
                Email = user.Email,
                Roles = user.Roles
            });

            // Save the image
            var imagePathInfo = new DirectoryInfo($"{WebHostEnvironment.WebRootPath}/images");

            // Check if the folder "images" exist
            if (!imagePathInfo.Exists)
            {
                imagePathInfo.Create();
            }

            // Determine the image name
            var fileName = new FileInfo($"{imagePathInfo}/{user.Name}.png");

            // Write the file content
           //await File.WriteAllBytesAsync(fileName.FullName, users.Image);

            // Save the data
            await LocalStorage.SetItemAsync("data", currentData);
        }
        /*
        private async Task LoadImage(InputFileChangeEventArgs e)
        {
            // Set the content of the image to the model
            using (var memoryStream = new MemoryStream())
            {
                await e.File.OpenReadStream().CopyToAsync(memoryStream);
                user.Image = memoryStream.ToArray();
            }
        }
        */
        /*
        private void OnEnchantCategoriesChange(string item, object checkedValue)
        {
            if ((bool)checkedValue)
            {
                if (!user.Roles.Contains(item))
                {
                    user.Roles.Add(item);
                }

                return;
            }
        }
        */
    }
}