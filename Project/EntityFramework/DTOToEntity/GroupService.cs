using DbContextLib;
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
    public class GroupService : IGroupService
    {

        private readonly StubbedContext context = new StubbedContext();

        public GroupService()
        {

        }

        public GroupService(StubbedContext context)
        {
            this.context = context;
        }
        public async Task<GroupDTO> Add(GroupDTO group)
        {
            if(group == null)
            {
                throw new ArgumentNullException();
            }
          var groupEntity = group.ToEntity();
            var res = context.Groups.Add(groupEntity);
            await context.SaveChangesAsync();

            return res.Entity.ToDTO(); ;
        }

        public async Task<UserDTO> AddUserToGroup(long idUser, long idGroup)
        {
            var group = context.Groups.Find(idGroup);
            if (group == null)
            {
                throw new Exception("Group not found");
            }
            var user = context.Users.Find(idUser);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            group.Users.Add(user);
            await context.SaveChangesAsync();
            return user.ToDTO();

        }

        public async Task<VocabularyListDTO> AddVocabularyListToGroup(long vocabId, long groupId)
        {
            var group = context.Groups.Find(groupId);
            if (group == null)
            {
                throw new Exception("Group not found");
            }
            var vocab = context.VocabularyLists.Find(vocabId);
            if (vocab == null)
            {
                throw new Exception("VocabularyList not found");
            }
            group.GroupVocabularyList.Add(vocab);
            await context.SaveChangesAsync();
            return vocab.ToDTO();

        }

        public async Task<GroupDTO> Delete(object id)
        {
            var group = await context.Groups.FindAsync((long)id);
            if (group != null)
            { 
                context.Groups.Remove(group);
                await context.SaveChangesAsync();
            }else
            {
                throw new Exception("Group not found");
            }
            return group.ToDTO();
        }

        public async Task<GroupDTO> GetById(object id)
        {
            var group = await context.Groups.FindAsync((long)id);
            if (group == null)
            {
                throw new Exception("Group not found");
            }
            return group.ToDTO();
        }

        public async Task<PageResponse<GroupDTO>> GetByNum(int index, int count, int num)
        {
            var  groups = context.Groups.Where(g => g.Num == num).Skip(index * count).Take(count);
            return new PageResponse<GroupDTO>(groups.ToList().Select(g => g.ToDTO()), context.Groups.Count());
        }

        public async Task<PageResponse<GroupDTO>> GetBySector(int index, int count, string sector)
        {
            var groups = context.Groups.Where(g => g.sector == sector).Skip(index * count).Take(count);
            return new PageResponse<GroupDTO>(groups.ToList().Select(g => g.ToDTO()), context.Groups.Count());
        }

        public async Task<PageResponse<GroupDTO>> GetByYear(int index, int count, int year)
        {
            var groups = context.Groups.Where(g => g.year == year).Skip(index * count).Take(count);
            return new PageResponse<GroupDTO>(groups.ToList().Select(g => g.ToDTO()), context.Groups.Count());
        }

        public async Task<PageResponse<GroupDTO>> Gets(int index, int count)
        {
            IEnumerable<GroupEntity> groups = await context.Groups.Skip(index * count).Take(count).ToListAsync();
            return new PageResponse<GroupDTO>(groups.ToList().Select(g => g.ToDTO()), context.Groups.Count());
        }

        public async Task<GroupDTO> Update(GroupDTO group)
        {
            if(group == null)
            {
                throw new ArgumentNullException();
            }
            var existingGroup = await context.Groups.FindAsync(group.Id);
            if (existingGroup == null)
            {
                throw new Exception("Group not found");
            }
            existingGroup.year = group.Year;
            existingGroup.sector = group.sector;
            existingGroup.Num = group.Num;
            await context.SaveChangesAsync();
            return existingGroup.ToDTO();
        }
    }


}
