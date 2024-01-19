namespace adminBlazor.Models
{
    using System.ComponentModel.DataAnnotations;

    public class LoginRequest
    {
        [Required]
        public string Password { get; set; }

        [Required]
        public string UserName { get; set; }
    }
}