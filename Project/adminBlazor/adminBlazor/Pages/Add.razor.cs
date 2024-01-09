using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components;
using adminBlazor.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using adminBlazor.Services;

namespace adminBlazor.Pages
{
    public partial class Add
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public ILocalStorageService LocalStorage { get; set; }
        [Inject]
        public IDataService DataService { get; set; }

        [Inject]
        public IWebHostEnvironment WebHostEnvironment { get; set; }


        /// <summary>
        /// The default enchant categories.
        /// </summary>
        private List<string> roles = new List<string>() { "admin","teacher", "student" };


        /// <summary>
        /// The current item model
        /// </summary>
        private Models.UserModel user = new Models.UserModel()
        {
            Roles = new List<string>()
    };

        private async void HandleValidSubmit()
        {
            await DataService.Add(user);
            

            NavigationManager.NavigateTo("list");
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
                    user.Roles.Remove(currentItem);
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
                user.Roles.Remove(currentItem);
            }
        }
        private void RolesCategoriesChange(string item, object checkedValue)
        {
            if (item == "student")
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
                    user.Roles.Remove(item);
                }
            }
            else
            {
                if (disableOtherCheckboxes)
                {
                    //la case student a été coché ducoup on n'ajoute pas les autres rôles cochés
                    return;
                    if ((bool)checkedValue)
                    {
                        if (!user.Roles.Contains(item))
                        {
                            user.Roles.Add(item);
                        }
                    }
                    else
                    {
                        user.Roles.Remove(item);
                    }
                }
            }
        }
    }
}