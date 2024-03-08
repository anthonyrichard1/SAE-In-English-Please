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
    public class GroupService : IService<GroupDTO>
    {
        private readonly StubbedContext context = new StubbedContext();

        public GroupService()
        {
            //this.context = context;
        }
        public async Task<GroupDTO> Add(GroupDTO group)
        {
          var groupEntity = group.ToEntity();
            var res = context.Groups.Add(groupEntity);
            await context.SaveChangesAsync();

            return res.Entity.ToDTO(); ;
        }

        public async Task<GroupDTO> Delete(object id)
        {
            var group = await context.Groups.FindAsync(id);
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
            var group = await context.Groups.FindAsync(id);
            if (group == null)
            {
                throw new Exception("Group not found");
            }
            return group.ToDTO();
        }

        public async Task<IEnumerable<GroupDTO>> Gets()
        {
            IEnumerable<GroupEntity> groups = await context.Groups.ToListAsync();
            return groups.ToList().Select(g => g.ToDTO());
        }

        public async Task<GroupDTO> Update(GroupDTO group)
        {
            var groupEntity = group.ToEntity();
            var res = context.Groups.Update(groupEntity);
            await context.SaveChangesAsync();
            return res.Entity.ToDTO();
        }
    }
}
