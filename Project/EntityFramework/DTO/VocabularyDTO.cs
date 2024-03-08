using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class VocabularyDTO
    {
        public string word { get; set; }
        public ICollection<TranslateDTO> translations { get; set; } = new List<TranslateDTO>();

        public string LangueName { get; set; }
        public LangueDTO? Langue { get; set; } = null!;
    }
}
