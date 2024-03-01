using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modele
{
    public class UserDTO
    {
        public long Id { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string NickName { get; set; }
        public string? image { get; set; } = null;
        public long GroupId { get; set; }
        public GroupDTO? Group { get; set; } = null;
        public long RoleId { get; set; }
        public RoleDTO? Role { get; set; } = null!;
        public Boolean ExtraTime { get; set; }
        public ICollection<VocabularyListDTO> VocabularyList { get; set; } = new List<VocabularyListDTO>();
    }
}
