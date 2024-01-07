﻿using System.Linq.Expressions;

namespace AkarSoftware.ApiBestPractise.Core.Services
{
    public interface IService<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        IQueryable<T> Where(Expression<Func<T, bool>> expression);
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> Entities);
        Task Update(T entity);
        Task Delete(T entity); // içerisinde dbcontext işlemleri olacağı için bu sebeple biz bunları bu şekilde çevirdik .
        void RemoveRange(IEnumerable<T> Entitites);
    }
}
