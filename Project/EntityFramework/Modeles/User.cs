using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modeles
{
    public class User
    {
        public long Id { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string NickName { get; set; }
        public string? image { get; set; } = null;
        //public long Group { get; set; }
        //public string Role { get; set; }
        public Boolean ExtraTime { get; set; }
    }
}
