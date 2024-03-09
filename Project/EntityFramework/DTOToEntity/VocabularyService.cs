using DTO;
using Entities;
using Microsoft.EntityFrameworkCore;
using StubbedContextLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOToEntity
{
    public class VocabularyService : IService<VocabularyDTO>
    {
        private readonly StubbedContext _context = new StubbedContext();
        public async Task<VocabularyDTO> Add(VocabularyDTO vocabulary)
        {
           var vocabularyEntity = vocabulary.ToEntity();
            if(vocabularyEntity == null)
            {
                throw new ArgumentNullException();
            }
           await _context.Vocabularys.AddAsync(vocabularyEntity);
           await _context.SaveChangesAsync();
           return vocabularyEntity.ToDTO();
        }

        public async Task<VocabularyDTO> Delete(object id)
        {
            var vocabulary = await _context.Vocabularys.FirstOrDefaultAsync(v => v.word == (string)id);
            if(vocabulary == null)
            {
                throw new Exception("Vocabulary not found");
            }
            _context.Vocabularys.Remove(vocabulary);
            await _context.SaveChangesAsync();
            return vocabulary.ToDTO();
        }

        public async Task<VocabularyDTO> GetById(object id)
        {
            var vocabulary = await _context.Vocabularys.FirstOrDefaultAsync(v => v.word == (string)id);
            if(vocabulary == null)
            {
                throw new Exception("Vocabulary not found");
            }
            return vocabulary.ToDTO();
        }

        public async Task<PageResponse<VocabularyDTO>> Gets(int index, int count)
        {
            var vocabulary = await _context.Vocabularys.Skip(index).Take(count).ToListAsync();
            return new PageResponse<VocabularyDTO>(vocabulary.Select(v => v.ToDTO()), _context.Vocabularys.Count());
        }

        public async Task<VocabularyDTO> Update(VocabularyDTO vocabulary)
        {
            VocabularyEntity vocabularyEntity = vocabulary.ToEntity();
            if(vocabularyEntity == null)
            {
                throw new Exception("vocabulary not valid");
            }
            var VocabToUpdate = _context.Vocabularys.FirstOrDefault(v => v.word == (string)vocabularyEntity.word);
            if(VocabToUpdate == null)
            {
                throw new Exception("vocabulary not found");
            }
            _context.Vocabularys.Update(vocabularyEntity);
            await _context.SaveChangesAsync();
            return vocabularyEntity.ToDTO();
        }
    }
}
