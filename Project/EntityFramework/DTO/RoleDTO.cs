using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class RoleDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        //public ICollection<UserDTO> Users { get; set; } = new List<UserDTO>();
    }
}
