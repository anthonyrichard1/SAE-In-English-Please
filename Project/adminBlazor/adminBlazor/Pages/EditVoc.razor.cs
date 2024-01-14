using adminBlazor.Factories;
using adminBlazor.Models;
using adminBlazor.Services;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
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


        protected async Task OnInitializedAsync()
        {
            var item = await VocListService.GetById(Id);

            voc = VocListFactory.ToModel(item);
        }
    }
}
