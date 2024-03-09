using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class VocabularyListDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }

        public long UserId { get; set; }
        //public UserDTO User { get; set; } = null!;

        //public ICollection<TranslateDTO> translation { get; set; } = new List<TranslateDTO>();
        //public ICollection<GroupDTO> Groups { get; set; } = new List<GroupDTO>();
    }
}
