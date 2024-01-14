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
                id = voc.id,
                name = voc.name,
                image = voc.image,
                aut = voc.aut
            };
        }

        public static VocabularyList Create(VocabularyListModel voc)
        {
            return new VocabularyList
            {
                id = voc.id,
                name = voc.name,
                image = voc.image,
                aut = voc.aut
            };
        }
        public static void Update(VocabularyList item, VocabularyListModel voc)
        {
            if (!string.IsNullOrEmpty(voc.name))
                item.name = voc.name;

            if (!string.IsNullOrEmpty(voc.image))
                item.image = voc.image;
        }

    }

}

