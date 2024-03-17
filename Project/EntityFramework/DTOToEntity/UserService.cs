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
    public class UserService : IUserService
    {
        private StubbedContext _context = new StubbedContext();

        public UserService() { }
        public UserService(StubbedContext context)
        {
            _context = context;
        }
        public async Task<UserDTO> Add(UserDTO user)
        {
            UserEntity userEntity = user.ToEntity();
            if(userEntity == null)
            {
                throw new Exception("User Entity is null");
            }
            var result = _context.Users.Add(userEntity);
            await _context.SaveChangesAsync();
            return result.Entity.ToDTO();
        }

        public async Task<UserDTO> Delete(object id)
        {
            UserEntity? user = await _context.Users.FirstOrDefaultAsync(u => u.Id == (long)id);
            if(user == null)
            {
                throw new Exception("User not found");
            }
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return user.ToDTO();
        }

        public async Task<PageResponse<UserDTO>> GetByGroup(int index, int count, long group)
        {
            var users = _context.Users.Where(u => u.GroupId == group).Skip(index * count).Take(count);
            return new PageResponse<UserDTO>(users.Select(u => u.ToDTO()), _context.Users.Count());
        }

        public async Task<UserDTO> GetById(object id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == (long)id);
            if(user == null)
            {
                throw new Exception("User not found");
            }
            return user.ToDTO();
        }

        public async Task<PageResponse<UserDTO>> GetByRole(int index, int count, string role)
        {

            var users = _context.Users.Where(u => u.Role.Name == role).Skip(index * count).Take(count);
            return new PageResponse<UserDTO>(users.Select(u => u.ToDTO()), _context.Users.Count());
        }

        public async Task<PageResponse<UserDTO>> Gets(int index, int count)
        {
            IEnumerable<UserEntity> users = await _context.Users.Skip(index * count).Take(count).ToListAsync();
            return new PageResponse<UserDTO>( users.Select(u => u.ToDTO()),_context.Users.Count());
        }

        public async Task<UserDTO> Update(UserDTO user)
        {
            if(user == null)
            {
                throw new Exception("User is null");
            }
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Id == user.Id);
            if(existingUser == null)
            {
                throw new Exception("User not found");
            }
            existingUser.image = user.image;
            existingUser.Name = user.Name;
            existingUser.Password = user.Password;
            existingUser.NickName = user.NickName;
            existingUser.Email = user.Email;
            existingUser.RoleId = user.RoleId;
            existingUser.GroupId = user.GroupId;
            existingUser.UserName = user.UserName;
            existingUser.ExtraTime = user.ExtraTime;

            await _context.SaveChangesAsync();
            return existingUser.ToDTO();
        }
    }
}
