using adminBlazor.Models;
using Microsoft.AspNetCore.Hosting;
using Blazored.LocalStorage;
using adminBlazor.Factories;
using Microsoft.AspNetCore.Components;

namespace adminBlazor.Services
{

    public interface IVocListService
    {

        Task Add(VocabularyListModel model);

        Task<int> Count();

        Task<List<VocabularyList>> List(int currentPage, int pageSize);

        Task<VocabularyList> GetById(int id);

        Task Update(int id, VocabularyListModel model);

        Task Delete(int id);
    }
}