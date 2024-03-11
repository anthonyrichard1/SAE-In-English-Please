using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOToEntity
{
    public interface IGroupService : IService<GroupDTO>
    {
        Task<PageResponse<GroupDTO>> GetByNum(int index, int count, int num);
        Task<PageResponse<GroupDTO>> GetBySector(int index, int count, string sector);
        Task<PageResponse<GroupDTO>> GetByYear(int index, int count, int year);
    }
}
