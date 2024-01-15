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
        public static VocabularyListModel ToModel(VocabularyList voc)
        {
            return new VocabularyListModel
            {
                Id = voc.Id,
                Name = voc.Name,
                Image = voc.Image,
                Aut = voc.Aut
            };
        }

        public static VocabularyList Create(VocabularyListModel voc)
        {
            return new VocabularyList
            {
                Id = voc.Id,
                Name = voc.Name,
                Image = voc.Image,
                Aut = voc.Aut
            };
        }
        public static void Update(VocabularyList item, VocabularyListModel voc)
        {
            if (!string.IsNullOrEmpty(voc.Name))
                item.Name = voc.Name;

            if (!string.IsNullOrEmpty(voc.Image))
                item.Image = voc.Image;
        }

    }

}

