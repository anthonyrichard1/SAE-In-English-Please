namespace adminBlazor.Models
{
    public class User
    {
        public int id { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string nickname { get; set; }
        public string image {  get; set; }
        public bool extraTime { get; set; }
        public int group {  get; set; }
        public string[] roles { get; set; }

    }
}
