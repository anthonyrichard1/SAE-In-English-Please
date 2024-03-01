using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modele
{
    public class Translate
    {
        public int Id { get; set; }

        [ForeignKey(nameof(WordsId))]
        public string WordsId { get; set; }
        public ICollection<Vocabulary> Words { get; set; } = new List<Vocabulary>();
        public long VocabularyListVocId { get; set; }
        public VocabularyList VocabularyListVoc { get; set; } = null!;
    }
}
