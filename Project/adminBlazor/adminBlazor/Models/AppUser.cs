namespace adminBlazor.Models
{
    public class AppUser
    {
        public string Password { get; set; }
        public List<string> Roles { get; set; }
        public string UserName { get; set; }
    }
}
