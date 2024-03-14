using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class GroupEntity
    {
        [Key]
        public long Id { get; set; }
        public int Num { get; set; }
        public int year { get; set; }
        public string sector { get; set; }
        public ICollection<UserEntity> Users { get; set; } = new List<UserEntity>();

        public ICollection<VocabularyListEntity> VocabularyList { get; set; } = new List<VocabularyListEntity>();

        public string toString()
        {
            return "Id: " + Id + " Num: " + Num + " year: " + year + " sector: " + sector;
        }

    }

}
