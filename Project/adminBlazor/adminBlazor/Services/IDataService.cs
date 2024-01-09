using adminBlazor.Models;
using Microsoft.AspNetCore.Hosting;
using Blazored.LocalStorage;
namespace adminBlazor.Services
{

    public interface IDataService
    {

        Task Add(UserModel model);

        Task<int> Count();

        Task<List<User>> List(int currentPage, int pageSize);

        Task<User> GetById(int id);

        Task Update(int id, UserModel model);

        Task Delete(int id);
    } 
   
}
