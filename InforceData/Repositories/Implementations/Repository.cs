﻿using InforceData.Data;
using InforceData.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InforceData.Repositories.Implementations {
    public abstract class Repository<T> : IRepository<T> where T : class {
        protected readonly DbSet<T> dbSet;
        protected readonly InforceDbContext dbContext;
        protected Repository(InforceDbContext context) {
            dbContext = context;
            dbSet = context.Set<T>();
        }
        public async Task<T> AddAsync(T entity) {
            await dbSet.AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(T entity) {
            dbSet.Remove(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id) {
            var entity = await GetByIdAsync(id);
            await Delete(entity);

        }

        public async Task<IEnumerable<T>> GetAllAsync() {
            return await dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id) {
            var entity = await dbSet.FindAsync(id);
            return entity;
        }


        public async Task<T> Update(T entity) {
            dbSet.Update(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
