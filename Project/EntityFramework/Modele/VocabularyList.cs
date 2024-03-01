using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modele
{
    public class VocabularyList
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }

        public long UserId { get; set; }
        public User User { get; set; } = null!;
        public ICollection<Translate> translation { get; set; } = new List<Translate>();
        public ICollection<Group> Groups { get; set; } = new List<Group>();
    }
}
