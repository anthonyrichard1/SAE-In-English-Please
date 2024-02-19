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
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }

        [ForeignKey(nameof(UserId))]
        public long UserId { get; set; }
        public UserEntity User { get; set; } = null!;

        public ICollection<TranslateEntity> translation { get; set; } = new List<TranslateEntity>();
        public ICollection<GroupEntity> Groups { get; } = new List<GroupEntity>();
    }
}
