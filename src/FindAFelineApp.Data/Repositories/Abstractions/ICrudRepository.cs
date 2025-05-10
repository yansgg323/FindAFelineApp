﻿using FindAFelineApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FindAFelineApp.Data.Repositories.Abstractions
{
    public interface ICrudRepository<T>
    where T : BaseEntity
    {
        public Task AddAsync(T entity);
        public Task UpdateAsync(T entity);
        public Task DeleteByIdAsync(int id);
        public Task<IEnumerable<T>> GetLatestAsync(int limit);
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T> GetByIdAsync(int id);
        public Task<IEnumerable<T>> GetByFilterAsync(Expression<Func<T, bool>> predicate);
        
    }
}
