using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class VocabularyEntity
    {
        [Key]
        public string word {  get; set; }
    }
}
