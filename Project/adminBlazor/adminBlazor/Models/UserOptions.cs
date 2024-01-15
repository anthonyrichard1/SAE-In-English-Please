using System.Data;

namespace adminBlazor.Models
{
    public class UserOptions
    {
        public const string User = "User";

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Nickname { get; set; }
        public bool ExtraTime { get; set; }
        public int Group { get; set; }

        public List<string> Roles { get; set; }

        public UserOptions()
        {
            // Constructeur sans paramètre public
            Id = 1;
            Name = "DefaultName";
            Surname = "DefaultSurname";
            Nickname = "DefaultNickname";
            ExtraTime = false;
            Group = 0;
            Roles = new List<string>();
        }
    }
}
