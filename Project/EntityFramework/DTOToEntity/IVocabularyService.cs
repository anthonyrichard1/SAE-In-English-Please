using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOToEntity
{
    public interface IVocabularyService : IService<VocabularyDTO>
    {
        Task<PageResponse<VocabularyDTO>> GetByLangue(int index, int count, string langue);
    }
}
