using System;
using System.ComponentModel.DataAnnotations;

namespace adminBlazor.Models
{
    public class VocabularyListModel
    {
        [Required]
        public int id { get; set; }

        public string name { get; set; }

        public string image { get; set; }

        public int? aut { get; set; }
    }
}

