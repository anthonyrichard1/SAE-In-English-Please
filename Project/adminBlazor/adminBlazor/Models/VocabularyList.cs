using System;
namespace adminBlazor.Models
{
	public class VocabularyList
	{
		public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }
        public int? Aut { get; set; }
        
        public string? ImageBase64 { get; set; }
        public List<Translation>? Translations { get; set; }
	}
}

