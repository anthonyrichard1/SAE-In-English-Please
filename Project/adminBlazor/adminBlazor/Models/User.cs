namespace adminBlazor.Models
{
    public class User
    {
        private int id { get; set; }
        private string password { get; set; }
        private string email { get; set; }
        private string name { get; set; }
        private string surname { get; set; }
        private string nickname { get; set; }
        private string image {  get; set; }
        private bool extraTime { get; set; }
        private int group {  get; set; }
        private string[] roles { get; set; }

    }
}
