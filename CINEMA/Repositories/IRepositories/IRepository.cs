﻿using System.Linq.Expressions;

namespace CINEMA.Repositories.IRepositories
{
    public interface IRepository<T>where T : class
    {
        Task CreateAsync(T entity);
        void Edit(T entity);
        void Delete(T entity);
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>>? filter = null, Expression<Func<T, object>>[]? includes = null, bool tracked = true);
        Task<T?> GetOneAsync(Expression<Func<T, bool>>? filter = null, Expression<Func<T, object>>[]? includes = null, bool tracked = true);
        Task<bool> CommitAsync();

    }
}
