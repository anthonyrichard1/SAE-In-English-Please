using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modele
{
    public class VocabularyDTO
    {
        public string word { get; set; }
        //public ICollection<TranslateEntity> translations { get; } = new List<TranslateEntity>();

        public string LangueName { get; set; }
        //public LangueEntity? Langue { get; set; } = null!;
    }
}
