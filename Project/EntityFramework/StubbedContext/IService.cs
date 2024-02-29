using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StubbedContextLib
{
    public interface IService<T>
    {
        Task<IEnumerable<T>> GetGroups();
        Task<T> GetGroup(int id);
        Task<T> AddGroup(T group);
        Task<T> DeleteGroup(int id);
        Task<T> UpdateGroup(T group);
    }
}
