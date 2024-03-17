using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOToEntity
{
    public interface ITranslateService : IService<TranslateDTO>
    {
        Task<VocabularyDTO> AddVocabToTranslate(string vocabId, long translateId);
    }
}
