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
            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();
            return role.ToDTO();
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

        public async Task<IEnumerable<RoleDTO>> Gets()
        {
           IEnumerable<RoleEntity> roles = await _context.Roles.ToListAsync();
            return roles.ToList().Select(r => r.ToDTO());
        }

        public async Task<RoleDTO> Update(RoleDTO role)
        {
            RoleEntity? roleEntity = await _context.Roles.FirstOrDefaultAsync(r => r.Id == role.Id);
            if (role == null)
            {
                throw new Exception("Role not found");
            }
            roleEntity= role.ToEntity();
            _context.Roles.Update(roleEntity);
            await _context.SaveChangesAsync();
            return roleEntity.ToDTO();
        }
    }
}
