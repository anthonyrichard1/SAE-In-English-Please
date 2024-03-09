using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DTOToEntity
{
    public interface IService<T>
    {
        Task<PageResponse<T>> Gets(int index, int count);
        Task<T> GetById(object id);
        Task<T> Add( T group);
        Task<T> Delete(object id);
        Task<T> Update(T group);
    }
}
