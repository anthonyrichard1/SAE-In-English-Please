using adminBlazor.Models;
using Blazorise;
using Blazorise.Extensions;
using System.Data;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace adminBlazor.Factories
{
    public static class VocListFactory
    {
        public static VocabularyListModel ToModel(VocabularyList voc, byte[] imageContent)
        {
            VocabularyListModel model = new VocabularyListModel
            {
                Id = voc.Id,
                Name = voc.Name,
                Image = voc.Image,
                Aut = voc.Aut,
                ImageBase64 = string.IsNullOrWhiteSpace(voc.ImageBase64) ? Convert.ToBase64String(imageContent) : voc.ImageBase64
            };
                model.Translations = new List<TranslationModel>();
                foreach (var item in voc.Translations)
                {
                    model.Translations.Add(new TranslationModel
                    {
                        Id = item.Id,
                        FirstWord = item.FirstWord,
                        SecondWord = item.SecondWord
                    });
            }
            return model;
        }

        public static VocabularyList Create(VocabularyListModel voc)
        {
            VocabularyList model = new VocabularyList
            {
                Id = voc.Id,
                Name = voc.Name,
                Image = voc.Image,
                Aut = voc.Aut,
                ImageBase64 = voc.Image != null ? Convert.ToBase64String(voc.Image) : null
            };
            model.Translations = new List<Translation>();
            foreach (var item in voc.Translations)
            {
                model.Translations.Add(new Translation
                {
                    Id = item.Id,
                    FirstWord = item.FirstWord,
                    SecondWord = item.SecondWord
                });
            }
            return model;
        }
        public static void Update(VocabularyList item, VocabularyListModel voc)
        {
            if (!string.IsNullOrEmpty(voc.Name))
                item.Name = voc.Name;

            if (voc.ImageBase64 != null && voc.Image != null)
                item.ImageBase64 = Convert.ToBase64String(voc.Image);

            if (voc.Aut != null)
                item.Aut = voc.Aut;

            if (voc.Translations == null) return;
            item.Translations = new List<Translation>();
            foreach (var translation in voc.Translations)
            {
                item.Translations.Add(new Translation
                {
                    Id = translation.Id,
                    FirstWord = translation.FirstWord,
                    SecondWord = translation.SecondWord
                });
            }
        }

    }

}

