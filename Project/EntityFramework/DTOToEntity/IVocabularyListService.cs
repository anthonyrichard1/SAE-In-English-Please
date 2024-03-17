using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOToEntity
{
    public interface IVocabularyListService : IService<VocabularyListDTO>
    {
        Task<PageResponse<VocabularyListDTO>> GetByUser(int index, int count, int user);

        Task<GroupDTO> AddGroupToVocabularyList(long groupId, long vocabId);
    }
}
