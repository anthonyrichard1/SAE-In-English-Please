using adminBlazor.Models;

namespace adminBlazor.Factories;

public class TranslationFactory
{
    public static Translation Create(TranslationModel model)
    {
        return new Translation
        {
            Id = model.Id,
            FirstWord = model.FirstWord,
            SecondWord = model.SecondWord
        };
    }
    
    public static TranslationModel ToModel(Translation translation)
    {
        return new TranslationModel
        {
            Id = translation.Id,
            FirstWord = translation.FirstWord,
            SecondWord = translation.SecondWord
        };
    }
    
    public static void Update(Translation item, TranslationModel model)
    {
        if (!string.IsNullOrEmpty(model.FirstWord))
            item.FirstWord = model.FirstWord;

        if (!string.IsNullOrEmpty(model.SecondWord))
            item.SecondWord = model.SecondWord;
    }
}