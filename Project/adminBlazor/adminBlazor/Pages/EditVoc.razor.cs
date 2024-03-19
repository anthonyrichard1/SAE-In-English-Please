using adminBlazor.Factories;
using adminBlazor.Models;
using adminBlazor.Services;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;


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

        private VocabularyListModel voc = new VocabularyListModel();

        private async void HandleValidSubmit()
        {
            await VocListService.Update(Id, voc);

            NavigationManager.NavigateTo("voc");
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

        private void AddWord()
        {
            if (voc.Translations == null)
            {
                voc.Translations = new List<TranslationModel>();
            }
            voc.Translations.Add(new TranslationModel());
        }
        
        private void RemoveWord(TranslationModel word)
        {
            voc.Translations.Remove(word);
        }

        protected override async Task OnInitializedAsync()
        {
            var item = await VocListService.GetById(Id);

            var fileContent = await File.ReadAllBytesAsync($"{WebHostEnvironment.WebRootPath}/images/default.jpeg");
            
            voc = VocListFactory.ToModel(item,fileContent);
        }
    }
}