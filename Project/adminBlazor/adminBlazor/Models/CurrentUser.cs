namespace adminBlazor.Models
{
    using System.Collections.Generic;

    public class CurrentUser
    {
        public Dictionary<string, string> Claims { get; set; }
        public bool IsAuthenticated { get; set; }
        public string UserName { get; set; }
    }
}