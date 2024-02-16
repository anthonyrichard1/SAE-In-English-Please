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
            return new VocabularyListModel
            {
                Id = voc.Id,
                Name = voc.Name,
                Image = voc.Image,
                Aut = voc.Aut,
                ImageBase64 = string.IsNullOrWhiteSpace(voc.ImageBase64) ? Convert.ToBase64String(imageContent) : voc.ImageBase64
            };
        }

        public static VocabularyList Create(VocabularyListModel voc)
        {
            return new VocabularyList
            {
                Id = voc.Id,
                Name = voc.Name,
                Image = voc.Image,
                Aut = voc.Aut,
                ImageBase64 = voc.Image != null ? Convert.ToBase64String(voc.Image) : null
            };
        }
        public static void Update(VocabularyList item, VocabularyListModel voc)
        {
            if (!string.IsNullOrEmpty(voc.Name))
                item.Name = voc.Name;

            if (voc.ImageBase64 != null && voc.Image != null)
                item.ImageBase64 = Convert.ToBase64String(voc.Image);
        }

    }

}

