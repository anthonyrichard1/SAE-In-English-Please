using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeleToEntities
{
    public interface IService<T>
    {
        Task<IEnumerable<T>> Gets();
        Task<T> GetById(int id);
        Task<T> AddGroup(T group);
        Task<T> DeleteGroup(int id);
        Task<T> UpdateGroup(T group);
    }
}
