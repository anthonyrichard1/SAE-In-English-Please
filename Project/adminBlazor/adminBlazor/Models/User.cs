using System.ComponentModel.DataAnnotations;

namespace adminBlazor.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Nickname { get; set; }
        public bool ExtraTime { get; set; }
        public int Group { get; set; }
        public List<String> Roles { get; set; }
        public string? ImageBase64 { get; set; }
    }
}
