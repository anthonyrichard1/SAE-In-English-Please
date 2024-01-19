namespace adminBlazor.Models
{
    using System.ComponentModel.DataAnnotations;

    public class RegisterRequest
    {
        [Required]
        public string Password { get; set; }

        [Required]
        [Compare(nameof(Password), ErrorMessage = "Passwords do not match!")]
        public string PasswordConfirm { get; set; }

        [Required]
        public string UserName { get; set; }
    }
}