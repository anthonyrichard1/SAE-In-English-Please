using System;
using System.ComponentModel.DataAnnotations;

namespace adminBlazor.Models
{
    public class VocabularyListModel
    {
        [Required]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }

        public int? Aut { get; set; }
    }
}

