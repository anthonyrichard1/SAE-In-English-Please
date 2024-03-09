using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TranslateDTO
    {
        public int Id { get; set; }

        [ForeignKey(nameof(WordsId))]
        public string WordsId { get; set; }
       //public ICollection<VocabularyDTO> Words { get; set; } = new List<VocabularyDTO>();

        [ForeignKey(nameof(VocabularyListVocId))]
        public long VocabularyListVocId { get; set; }
        //public VocabularyListDTO VocabularyListVoc { get; set; } = null!;
    }
}
