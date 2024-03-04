using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using StubbedContextLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeleToEntities
{
    public class GroupService : IService<GroupEntity>
    {
        private readonly StubbedContext _context = new StubbedContext();

        public GroupService()
        {

        }

        public async Task<GroupEntity> AddGroup(GroupEntity group)
        {
            _context.Groups.Add(group);
            await _context.SaveChangesAsync();
            return group;
        }

        public async Task<GroupEntity> DeleteGroup(int id)
        {
            var group = await _context.Groups.FindAsync(id);
            if (group != null)
            {
                _context.Groups.Remove(group);
                await _context.SaveChangesAsync();
            }
            return group;
        }

        public async Task<GroupEntity> GetById(int id)
        {
            var group = await _context.Groups.FindAsync(id);
            if (group == null)
            {
                throw new Exception("Group not found");
            }
            return group;
        }

        public async Task<IEnumerable<GroupEntity>> Gets()
        {
            var groups = await _context.Groups.ToListAsync();
            return groups;
        }

        public async Task<GroupEntity> UpdateGroup(GroupEntity group)
        {
            var groupToUpdate = await _context.Groups.FindAsync(group.Id);
            if (groupToUpdate == null)
            {
                throw new Exception("Group not found");
            }
            groupToUpdate.sector = group.sector;
            groupToUpdate.year = group.year;
            await _context.SaveChangesAsync();
            return groupToUpdate;
        }
    }
}
