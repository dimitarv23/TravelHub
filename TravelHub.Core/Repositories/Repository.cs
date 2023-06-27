﻿namespace TravelHub.Core.Repositories
{
    using TravelHub.Infrastructure;
    using System.Linq.Expressions;
    using Microsoft.EntityFrameworkCore.ChangeTracking;
    using Microsoft.EntityFrameworkCore;

    public class Repository : IRepository
    {
        protected TravelHubContext dbContext { get; set; }

        protected DbSet<T> DbSet<T>() where T : class
        {
            return this.dbContext.Set<T>();
        }

        public Repository(TravelHubContext context)
        {
            dbContext = context;
        }

        public async Task AddAsync<T>(T entity) where T : class
        {
            await DbSet<T>().AddAsync(entity);
        }

        public async Task AddRangeAsync<T>(IEnumerable<T> entities) where T : class
        {
            await DbSet<T>().AddRangeAsync(entities);
        }

        public IQueryable<T> All<T>() where T : class
        {
            return DbSet<T>().AsQueryable();
        }

        public IQueryable<T> All<T>(Expression<Func<T, bool>> search) where T : class
        {
            return this.DbSet<T>().Where(search);
        }

        public IQueryable<T> AllReadonly<T>() where T : class
        {
            return this.DbSet<T>()
                .AsNoTracking();
        }
        public IQueryable<T> AllReadonly<T>(Expression<Func<T, bool>> search) where T : class
        {
            return this.DbSet<T>()
                .Where(search)
                .AsNoTracking();
        }

        public void Attach<T>(T entity) where T : class
        {
            this.DbSet<T>().Attach(entity);
        }

        public void AttachRange<T>(ICollection<T> entities) where T : class
        {
            this.DbSet<T>().AttachRange(entities);
        }

        public async Task DeleteAsync<T>(object id) where T : class
        {
            T entity = await GetByIdAsync<T>(id);

            Delete<T>(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            EntityEntry entry = this.dbContext.Entry(entity);

            if (entry.State == EntityState.Detached)
            {
                this.DbSet<T>().Attach(entity);
            }

            entry.State = EntityState.Deleted;
        }

        public void Detach<T>(T entity) where T : class
        {
            EntityEntry entry = this.dbContext.Entry(entity);

            entry.State = EntityState.Detached;
        }

        public void Dispose()
        {
            this.dbContext.Dispose();
        }

        public async Task<T> GetByIdAsync<T>(object id) where T : class
        {
            return (await DbSet<T>().FindAsync(id))!;
        }

        public async Task<T> GetByIdsAsync<T>(object[] id) where T : class
        {
            return (await DbSet<T>().FindAsync(id))!;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await this.dbContext.SaveChangesAsync();
        }

        public void Update<T>(T entity) where T : class
        {
            this.DbSet<T>().Update(entity);
        }

        public void UpdateRange<T>(IEnumerable<T> entities) where T : class
        {
            this.DbSet<T>().UpdateRange(entities);
        }

        public void DeleteRange<T>(IEnumerable<T> entities) where T : class
        {
            this.DbSet<T>().RemoveRange(entities);
        }

        public void DeleteRange<T>(Expression<Func<T, bool>> deleteWhereClause) where T : class
        {
            var entities = All<T>(deleteWhereClause);
            DeleteRange(entities);
        }
    }
}