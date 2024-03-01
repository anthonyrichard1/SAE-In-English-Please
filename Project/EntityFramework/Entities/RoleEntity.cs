﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class RoleEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<UserEntity> Users { get; set; } = new List<UserEntity>();

        public string toString()
        {
            return Id +" " + Name;
        }
    }
}
