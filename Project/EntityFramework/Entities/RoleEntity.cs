using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class RoleEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public ICollection<UserEntity> Users { get; set; } = new List<UserEntity>();

        public string toString()
        {
            return Id +" " + Name;
        }
    }
}
