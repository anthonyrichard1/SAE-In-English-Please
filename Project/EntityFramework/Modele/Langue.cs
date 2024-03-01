using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modele
{
    public class Langue
    {
        public string name { get; set; }

        public ICollection<Vocabulary> vocabularys { get; set; } = new List<Vocabulary>();
    }
}
