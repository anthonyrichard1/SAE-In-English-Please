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
    public class LangueService : IService<LangueDTO>
    {
        private readonly StubbedContext _context = new StubbedContext();
        public LangueService() { }
        public async Task<LangueDTO> Add(LangueDTO langue)
        {
            var langueEntity = langue.ToEntity();
            var res = _context.Langues.Add(langueEntity);
            await _context.SaveChangesAsync();
            return res.Entity.ToDTO();
            
        }

        public async Task<LangueDTO> Delete(object id)
        {
            var langue = await _context.Langues.FindAsync(id);
            if (langue != null)
            {
                _context.Langues.Remove(langue);
                await _context.SaveChangesAsync();
            }
            else { 
                throw new Exception("Langue not found");
            }
            return langue.ToDTO();
        }

        public async Task<LangueDTO> GetById(object id)
        {
            var langue = await _context.Langues.FindAsync(id);
            if (langue == null)
            {
                throw new Exception("Langue not found");
            }
            return langue.ToDTO();

        }

        public async Task<IEnumerable<LangueDTO>> Gets()
        {
            var langues = await _context.Langues.ToListAsync();
            return langues.Select(l => l.ToDTO());
        }

        public async Task<LangueDTO> Update(LangueDTO langue)
        {
            LangueEntity? langueToUpdate = await _context.Langues.FindAsync(langue.name);
            if (langueToUpdate == null)
            {
                throw new Exception("Langue not found");
            }
            langueToUpdate.vocabularys = (ICollection<VocabularyEntity>)langue.vocabularys.Select(v => v.ToEntity());
            return langueToUpdate.ToDTO();
        }
    }
}
