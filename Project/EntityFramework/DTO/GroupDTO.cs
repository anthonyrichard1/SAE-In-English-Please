namespace Modele
{
    public class GroupDTO
    {
        public int Id { get; set; }
        public int Num { get; set; }
        public int year { get; set; }
        public string sector { get; set; }
        public ICollection<UserDTO> Users { get; set; } = new List<UserDTO>();

        public ICollection<VocabularyListDTO> VocabularyList { get; set; } = new List<VocabularyListDTO>();


    }
}
