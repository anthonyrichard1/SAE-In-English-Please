﻿using System.ComponentModel.DataAnnotations;

namespace adminBlazor.Models
{
    public class UserModel
    {
        [Required]
        public int Id { get; set; }

        [StringLength(50, ErrorMessage = "Name length can't be more than 50.")]
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [StringLength(50, ErrorMessage = "Name length can't be more than 50.")]
        [Required]
        public string Name { get; set; }

        [StringLength(50, ErrorMessage = "Name length can't be more than 50.")]
        public string Surname { get; set; }

        [StringLength(50, ErrorMessage = "Name length can't be more than 50.")]
        public string Nickname { get; set; }


        public byte[] Image { get; set; }

        public bool ExtraTime { get; set; }

        [Range(0,100)]
        public int Group {  get; set; }

        public List<String> Roles { get; set; }
        public string ImageBase64 { get; set; }

    }
}
