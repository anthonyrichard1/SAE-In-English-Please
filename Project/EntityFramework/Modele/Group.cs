namespace Modele
{
    public class Group
    {
        public int Id { get; set; }
        public int Num { get; set; }
        public int year { get; set; }
        public string sector { get; set; }
        public ICollection<User> Users { get; set; } = new List<User>();

        public ICollection<VocabularyList> VocabularyList { get; set; } = new List<VocabularyList>();


    }
}
