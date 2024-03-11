using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOToEntity
{
    public interface IUserService : IService<UserDTO>
    {
        Task<PageResponse<UserDTO>> GetByGroup(int index, int count, int group);
        Task<PageResponse<UserDTO>> GetByRole(int index, int count, string role);
    }
}
