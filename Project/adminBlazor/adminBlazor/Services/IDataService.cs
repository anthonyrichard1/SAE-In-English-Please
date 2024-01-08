using adminBlazor.Models;
using Microsoft.AspNetCore.Hosting;
using Blazored.LocalStorage;
namespace adminBlazor.Services
{

    public interface IDataService
    {

        Task Add(UserModel model);

        Task<int> Count();

        Task<List<UserModel>> List(int currentPage, int pageSize);

        Task<UserModel> GetById(int id);

        Task Update(int id, UserModel model);
    } 
   
}
