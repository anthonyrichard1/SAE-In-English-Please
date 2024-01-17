using System.ComponentModel.DataAnnotations;

namespace adminBlazor.Models
{
    public class LoginRequest
    {
        [Required]
        public string Password { get; set; }

        [Required]
        public string UserName { get; set; }
    }
}
