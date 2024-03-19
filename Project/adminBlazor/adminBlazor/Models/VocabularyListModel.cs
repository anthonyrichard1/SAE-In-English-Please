using System;
using System.ComponentModel.DataAnnotations;

namespace adminBlazor.Models
{
    public class VocabularyListModel
    {
        [Required]
        public int Id { get; set; }

        public string Name { get; set; }

        public byte[] Image { get; set; }

        public int? Aut { get; set; }
        
        public string ImageBase64 { get; set; }
        public List<TranslationModel>? Translations { get; set; }
    }
}

