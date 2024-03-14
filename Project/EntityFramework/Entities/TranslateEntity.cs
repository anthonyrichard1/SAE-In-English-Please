using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class TranslateEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [ForeignKey(nameof(WordsId))]
        public string WordsId { get; set; }
        public ICollection<VocabularyEntity> Words { get; set; } = new List<VocabularyEntity>();

        [ForeignKey(nameof(VocabularyListVocId))]
        public long VocabularyListVocId { get; set; }
        public VocabularyListEntity? VocabularyListVoc { get; set; } = null!;

        public string toString()
        {
            return Id + "" + WordsId ;
        }
    }
}
