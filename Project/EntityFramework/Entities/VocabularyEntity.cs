﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class VocabularyEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string word {  get; set; }
        public ICollection<TranslateEntity> Voctranslations { get; set; } = new List<TranslateEntity>();

        [ForeignKey(nameof(LangueName))]
        public string LangueName { get; set; }
        public LangueEntity? Langue { get; set; } = null!;

        public string toString()
        {
            return word + " " + LangueName ;
        }

    }
}
