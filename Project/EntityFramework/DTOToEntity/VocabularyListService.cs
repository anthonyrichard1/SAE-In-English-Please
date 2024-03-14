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
    public class VocabularyListService : IVocabularyListService
    {
        private StubbedContext _context = new StubbedContext();

        public VocabularyListService()
        {
        }

        public VocabularyListService(StubbedContext context)
        {
            _context = context;
        }
        public async Task<VocabularyListDTO> Add(VocabularyListDTO group)
        {
            var groupEntity = group.ToEntity();
            _context.VocabularyLists.Add(groupEntity);
            await _context.SaveChangesAsync();
            return groupEntity.ToDTO();
        }

        public async Task<VocabularyListDTO> Delete(object id)
        {
            var group = await _context.VocabularyLists.FindAsync(id);
            if (group != null)
            {
                _context.VocabularyLists.Remove(group);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Group not found");
            }
            return group.ToDTO();
        }

        public async Task<VocabularyListDTO> GetById(object id)
        {
            var group = await _context.VocabularyLists.FindAsync(id);
            if (group == null)
            {
                throw new Exception("Group not found");
            }
            return group.ToDTO();
        }

        public async Task<PageResponse<VocabularyListDTO>> GetByUser(int index, int count, int user)
        {
            var groups = _context.VocabularyLists.Where(g => g.UserId == user).Skip(index).Take(count);
            return new PageResponse<VocabularyListDTO>(groups.Select(g => g.ToDTO()), _context.VocabularyLists.Count());

        }

        public async Task<PageResponse<VocabularyListDTO>> Gets(int index, int count)
        {
            var groups = await _context.VocabularyLists.Skip(index).Take(count).ToListAsync();
            return new PageResponse<VocabularyListDTO>(groups.Select(g => g.ToDTO()), _context.VocabularyLists.Count());
        }

        public async Task<VocabularyListDTO> Update(VocabularyListDTO group)
        {
            var groupEntity = group.ToEntity();
            if (groupEntity == null)
            {
                throw new Exception("Group Entity is null");
            }
            var res = _context.VocabularyLists.Update(groupEntity);
            await _context.SaveChangesAsync();
            return res.Entity.ToDTO();
        }
    }
}
