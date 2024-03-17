using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class VocabularyListEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }

        [ForeignKey(nameof(UserId))]
        public long UserId { get; set; }
        public UserEntity? User { get; set; } = null;

        public ICollection<TranslateEntity> translations { get; set; } = new List<TranslateEntity>();
        public ICollection<GroupEntity> VocsGroups { get; set; } = new List<GroupEntity>();

        public string toString()
        {
            return "Id : " + Id + " Name : " + Name + " Image : " + Image + " UserId : " + UserId;
        }
    }
}
