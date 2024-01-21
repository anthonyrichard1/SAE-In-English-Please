using adminBlazor.Factories;
using adminBlazor.Models;
using adminBlazor.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Hosting;


namespace adminBlazor.Pages
{
    public partial class EditUser
    {
        [Parameter]
        public int Id { get; set; }

        //IDataService
        [Inject]
        public IDataService DataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IWebHostEnvironment WebHostEnvironment { get; set; }



        /// <summary>
        /// The default roles.
        /// </summary>
        private List<string> roles = new List<string>() { "admin", "teacher", "student" };

        private UserModel user = new UserModel()
        {
            Roles = new List<string>()
        };
        /// <summary>
        /// The current item model
        /// </summary>
  

        private async void HandleValidSubmit()
        {
            

            await DataService.Update(Id, user);


            NavigationManager.NavigateTo("list");
        }


        protected override async Task OnInitializedAsync()
        {
            var item = await DataService.GetById(Id);

               var fileContent = await File.ReadAllBytesAsync($"{WebHostEnvironment.WebRootPath}/images/default.jpeg");

            // Set the model with the item

            user = UserFactory.ToModel(item,fileContent);
        }

        
        private async Task LoadImage(InputFileChangeEventArgs e)
        {
            // Set the content of the image to the model
            using (var memoryStream = new MemoryStream())
            {
                await e.File.OpenReadStream().CopyToAsync(memoryStream);
                user.Image = memoryStream.ToArray();
            }
        }
        
        private bool isStudentChecked = false;
        private bool disableOtherCheckboxes = false;

        private void StudentCheckboxChange(string currentItem, object checkedValue)
        {
            if (currentItem == "student")
            {
                if (isStudentChecked)
                {
                    // Activer les autres cases à cocher si "Étudiant" est cochée
                    disableOtherCheckboxes = true;
                    if (!user.Roles.Contains(currentItem))
                    {
                        user.Roles.Add(currentItem);
                    }
                }
                else
                {
                    // Désactiver les autres cases à cocher si "Étudiant" est décochée
                    disableOtherCheckboxes = false;
                    //user.Roles.Remove(currentItem);
                }
            }
        }

        private void OtherCheckboxChange(string currentItem)
        {
            if (isStudentChecked && currentItem != "student")
            {
                // Si "Étudiant" est coché, désactiver les autres cases
                disableOtherCheckboxes = true;
                if (!user.Roles.Contains(currentItem))
                {
                    user.Roles.Add(currentItem);
                }
            }
            else
            {
                // Sinon, activer les autres cases
                disableOtherCheckboxes = false;
                //user.Roles.Remove(currentItem);
            }
        }
        private void RolesCategoriesChange(string item, object checkedValue)
        {

            isStudentChecked = (bool)checkedValue;

            if (isStudentChecked)
            {
                // Activer les autres cases à cocher si "Étudiant" est cochée
                disableOtherCheckboxes = true;
                if (!user.Roles.Contains(item))
                {
                    user.Roles.Add(item);
                }
            }
            else
            {
                // Désactiver les autres cases à cocher si "Étudiant" est décochée
                disableOtherCheckboxes = false;
                //user.Roles.Remove(item);
            }
        }

    }
}
