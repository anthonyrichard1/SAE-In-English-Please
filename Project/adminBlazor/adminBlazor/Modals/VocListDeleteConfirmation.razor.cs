using Microsoft.AspNetCore.Components;
using Blazored.Modal;
using Blazored.Modal.Services;
using adminBlazor.Services;
using adminBlazor.Models;

namespace adminBlazor.Modals
{
    public partial class VocListDeleteConfirmation
    {
        [CascadingParameter]
        public BlazoredModalInstance ModalInstance { get; set; }

        [Inject]
        public IVocListService VocListService { get; set; }

        [Parameter]
        public int Id { get; set; }

        private VocabularyList item = new VocabularyList();

        protected override async Task OnInitializedAsync()
        {
            // Get the item
            item = await VocListService.GetById(Id);
        }

        void ConfirmDelete()
        {
            ModalInstance.CloseAsync(ModalResult.Ok(true));
        }

        void Cancel()
        {
            ModalInstance.CancelAsync();
        }
    }
}