using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modele
{
    public class Vocabulary
    {
        public string word { get; set; }
        public ICollection<Translate> translations { get; } = new List<Translate>();

        public string LangueName { get; set; }
        public Langue? Langue { get; set; } = null!;
    }
}
