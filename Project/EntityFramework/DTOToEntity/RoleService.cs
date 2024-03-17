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
    public class RoleService : IService<RoleDTO>
    {
        private readonly StubbedContext _context = new StubbedContext();

        public RoleService() { }
        public RoleService(StubbedContext context)
        {
            _context = context;
        }
        public async Task<RoleDTO> Add(RoleDTO role)
        {
            var roleEntity = role.ToEntity();
            if(roleEntity == null)
            {
                throw new ArgumentNullException();
            }
            var res = _context.Roles.Add(roleEntity);
            await _context.SaveChangesAsync();
            return res.Entity.ToDTO();
        }

        public async Task<RoleDTO> Delete(object id)
        {
            RoleEntity? role = await _context.Roles.FirstOrDefaultAsync(r => r.Id == (int)id);
            if (role == null)
            {
                throw new Exception("Role not found");
            }
            var res = _context.Roles.Remove(role);
            await _context.SaveChangesAsync();
            return res.Entity.ToDTO();
        }

        public async Task<RoleDTO> GetById(object id)
        {
            RoleEntity? role = await _context.Roles.FirstOrDefaultAsync(r => r.Id == (int)id);
            if (role == null)
            {
                throw new Exception("Role not found");
            }
            return role.ToDTO();
        }

        public async Task<PageResponse<RoleDTO>> Gets(int index, int count)
        {
           IEnumerable<RoleEntity> roles = await _context.Roles.Skip(index * count).Take(count).ToListAsync();
            return new PageResponse<RoleDTO>(roles.ToList().Select(r => r.ToDTO()), _context.Roles.Count());
        }

        public async Task<RoleDTO> Update(RoleDTO role)
        {
            if (role == null)
            {
                throw new ArgumentNullException();
            }
            var roleEntity = await _context.Roles.FindAsync(role.Id);
            if (roleEntity != null)
            {
                throw new Exception("role not found");
            }
            roleEntity.Name = role.Name;
            await _context.SaveChangesAsync();
            return roleEntity.ToDTO();
        }
    }
}