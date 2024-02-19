using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modeles
{
    public class VocabularyList
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        //public long User { get; set; }
    }
}
