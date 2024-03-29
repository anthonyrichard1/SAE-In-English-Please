﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class UserEntity
    {
        public long Id { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string NickName { get; set; }
        public string? image { get; set; } = null;

        [ForeignKey(nameof(GroupId))]
        public long GroupId { get; set; }

        public GroupEntity? Group { get; set; } = null;

        [ForeignKey(nameof(RoleId))]
        public long RoleId { get; set; }
        public RoleEntity? Role { get; set; } = null;
        public Boolean ExtraTime { get; set; }
        public ICollection<VocabularyListEntity> VocabularyList { get; set; } = new List<VocabularyListEntity>();


        public string toString()
        {
            return "Id: " + Id + " Password: " + Password + " Email: " + Email + " Name: " + Name + " UserName: " + UserName + " NickName: " + NickName + " GroupId: " + GroupId + " RoleId: " + RoleId + " ExtraTime: " + ExtraTime;
        }
    }


}
