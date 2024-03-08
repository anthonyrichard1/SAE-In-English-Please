using DbContextLib;
using DTO;
using Modele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ModeleToDTO
{
    public class GroupDataManager(LibraryContext _context) : IModele2DTO<GroupDTO, Group>
    {
        public Task<GroupDTO> Add(Group group)
        {
            throw new NotImplementedException();
        }

        public Task<GroupDTO> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<GroupDTO> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GroupDTO>> Gets()
        {
            throw new NotImplementedException();
        }

        public Task<GroupDTO> Update(Group group)
        {
            throw new NotImplementedException();
        }
    }
}
