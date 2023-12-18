using System.ComponentModel.DataAnnotations;

namespace adminBlazor.Models
{
    public class User
    {
        [Required]
        public int Id { get; set; }

        [StringLength(50, ErrorMessage = "Name length can't be more than 50.")]
        public string Password { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [StringLength(50, ErrorMessage = "Name length can't be more than 50.")]
        public string Name { get; set; }

        [StringLength(50, ErrorMessage = "Name length can't be more than 50.")]
        public string Surname { get; set; }

        [StringLength(50, ErrorMessage = "Name length can't be more than 50.")]
        public string Nickname { get; set; }

        [StringLength(50, ErrorMessage = "Name length can't be more than 50.")]
        public string Image {  get; set; }

        public bool ExtraTime { get; set; }
        public int Group {  get; set; }
        public string[] Roles { get; set; }

    }
}
