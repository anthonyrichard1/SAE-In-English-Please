using adminBlazor.Factories;
using adminBlazor.Models;
using adminBlazor.Services;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Hosting;


namespace adminBlazor.Pages
{
    public partial class EditVoc
    {
        [Parameter]
        public int Id { get; set; }

        [Inject]
        public IVocListService VocListService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IWebHostEnvironment WebHostEnvironment { get; set; }

        public VocabularyList currVoc;

        private VocabularyListModel voc = new VocabularyListModel();

        private async void HandleValidSubmit()
        {
            await VocListService.Update(Id, voc);

            NavigationManager.NavigateTo("list");
        }
        
        private async Task LoadImage(InputFileChangeEventArgs e)
        {
            // Set the content of the image to the model
            using (var memoryStream = new MemoryStream())
            {
                await e.File.OpenReadStream().CopyToAsync(memoryStream);
                voc.Image = memoryStream.ToArray();
            }
        }


        protected async Task OnInitializedAsync()
        {
            var item = await VocListService.GetById(Id);

            var fileContent = await File.ReadAllBytesAsync($"{WebHostEnvironment.WebRootPath}/images/default.jpeg");
            
            voc = VocListFactory.ToModel(item,fileContent);
        }
    }
}
