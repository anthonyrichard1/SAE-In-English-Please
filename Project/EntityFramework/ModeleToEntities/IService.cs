﻿using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeleToEntities
{
    public interface IService<T>
    {
        Task<IEnumerable<T>> Gets();
        Task<T> GetById(int id);
        Task<T> Add(T group);
        Task<T> Delete(int id);
        Task<T> Update(T group);
    }
}
