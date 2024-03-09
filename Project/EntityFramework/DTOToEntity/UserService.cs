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
    public class UserService : IService<UserDTO>
    {
        private StubbedContext _context = new StubbedContext();
        public async Task<UserDTO> Add(UserDTO user)
        {
            UserEntity? userEntity = user.ToEntity();
            if(userEntity == null)
            {
                throw new Exception("User Entity is null");
            }
            var result = await _context.Users.AddAsync(userEntity);
            await _context.SaveChangesAsync();
            return result.Entity.ToDTO();
        }

        public async Task<UserDTO> Delete(object id)
        {
            UserEntity? user = await _context.Users.FirstOrDefaultAsync(u => u.Id == (int)id);
            if(user == null)
            {
                throw new Exception("User not found");
            }
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return user.ToDTO();
        }

        public async Task<UserDTO> GetById(object id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == (int)id);
            if(user == null)
            {
                throw new Exception("User not found");
            }
            return user.ToDTO();
        }

        public async Task<IEnumerable<UserDTO>> Gets()
        {
            var users = await _context.Users.ToListAsync();
            return users.Select(u => u.ToDTO());
        }

        public async Task<UserDTO> Update(UserDTO user)
        {
            var userEntity = user.ToEntity();
            if(userEntity == null)
            {
                throw new Exception("User Entity is null");
            }
            if(_context.Users.FirstOrDefaultAsync(u => u.Id == userEntity.Id) == null)
            {
                throw new Exception("User not found");
            }
            var result = _context.Users.Update(userEntity);
            await _context.SaveChangesAsync();
            return result.Entity.ToDTO();
        }
    }
}
