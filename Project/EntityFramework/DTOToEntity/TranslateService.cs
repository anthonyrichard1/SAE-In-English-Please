using DTO;
using Microsoft.EntityFrameworkCore;
using StubbedContextLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOToEntity
{
    public class TranslateService : IService<TranslateDTO>
    {
        private readonly StubbedContext _context = new StubbedContext();

        public TranslateService() { }
        public TranslateService(StubbedContext context)
        {
            _context = context;
        }

        public async Task<TranslateDTO> Add(TranslateDTO translate)
        {
            var translateEntity = translate.ToEntity();
            _context.Translates.Add(translateEntity);
            await _context.SaveChangesAsync();
            return translateEntity.ToDTO();

        }

        public async Task<TranslateDTO> Delete(object id)
        {
            var translate = await _context.Translates.FirstOrDefaultAsync(t => t.Id == (int)id);
            if (translate != null)
            {
                _context.Translates.Remove(translate);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Translate not found");
            }
            return translate.ToDTO();
        }

        public async Task<TranslateDTO> GetById(object id)
        {
            var translate = await _context.Translates.FirstOrDefaultAsync(t => t.Id == (int)id);
            if (translate == null)
            {
                throw new Exception("Translate not found");
            }
            return translate.ToDTO();
        }

        public async Task<PageResponse<TranslateDTO>> Gets(int index, int count)
        {
            var translates = await _context.Translates.Skip(index).Take(count).ToListAsync();
            if(translates == null)
            {
                throw new Exception("No translates found");
            }
            return new PageResponse<TranslateDTO>( translates.Select(t => t.ToDTO()), _context.Translates.Count());
        }

        public async Task<TranslateDTO> Update(TranslateDTO translate)
        {
            var translateEntity = await _context.Translates.FirstOrDefaultAsync(t => t.Id == translate.Id);
            if (translateEntity == null)
            {
                throw new Exception("Translate not found");
            }
            translateEntity.WordsId = translate.WordsId;
            translateEntity.VocabularyListVocId = translate.VocabularyListVocId;
            _context.Translates.Update(translateEntity);
            await _context.SaveChangesAsync();
            return translateEntity.ToDTO();
        }
    }
}
