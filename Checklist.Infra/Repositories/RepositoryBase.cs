using CheckList.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Checklist.Infra.Repositories
{
    public class RepositoryBase<T> where T : class
    {
        protected readonly RDbContext _dbContext;

        internal readonly DbSet<T> _dbSet;

        protected RepositoryBase(RDbContext context)
        {
            _dbContext = context;
            _dbSet = _dbContext.Set<T>();
        }

        public async Task<T> Add(T entity)
        {
            using var transaction = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                Type entityType = typeof(T);

                PropertyInfo CreatedAtProperty = entityType.GetProperty("CreatedAt");

                CreatedAtProperty?.SetValue(entity, DateTime.Now);

                PropertyInfo UpdatedAtProperty = entityType.GetProperty("UpdatedAt");

                UpdatedAtProperty?.SetValue(entity, DateTime.Now);

                await _dbSet.AddAsync(entity);

                await _dbContext.SaveChangesAsync();

                transaction.Commit();

                return entity;
            }
            catch (Exception)
            {
                transaction.Rollback();

                throw;
            }
        }

        public async Task Update(T entity)
        {
            using var transaction = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                Type entityType = typeof(T);

                PropertyInfo UpdatedAtProperty = entityType.GetProperty("UpdatedAt");

                UpdatedAtProperty?.SetValue(entity, DateTime.Now);

                _dbSet.Update(entity);

                await _dbContext.SaveChangesAsync();

                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();

                throw;
            }
        }

        public async Task BulkInsert(List<T> entities)
        {
            using var transaction = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                Type entityType = typeof(T);

                foreach (var entity in entities)
                {
                    PropertyInfo CreatedAtProperty = entityType.GetProperty("CreatedAt");

                    CreatedAtProperty?.SetValue(entity, DateTime.Now);

                    PropertyInfo UpdatedAtProperty = entityType.GetProperty("UpdatedAt");

                    UpdatedAtProperty?.SetValue(entity, DateTime.Now);
                }

                await _dbSet.AddRangeAsync(entities);
                await _dbContext.SaveChangesAsync();

                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();

                throw;
            }
        }

        public async Task BulkUpdate(List<T> entities)
        {
            using var transaction = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                Type entityType = typeof(T);

                foreach (var entity in entities)
                {
                    PropertyInfo UpdatedAtProperty = entityType.GetProperty("UpdatedAt");

                    if (UpdatedAtProperty != null)
                    {
                        UpdatedAtProperty.SetValue(entity, DateTime.Now);
                    }
                }
                _dbSet.UpdateRange(entities);
                await _dbContext.SaveChangesAsync();

                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();

                throw;
            }
        }

        public DbSet<T> Query() => _dbSet;

        public async Task Delete(T entity)
        {
            if (entity != null)
            {
                Type entityType = typeof(T);

                PropertyInfo activeProperty = entityType.GetProperty("Active");

                PropertyInfo UpdatedAtProperty = entityType.GetProperty("UpdatedAt");

                using var transaction = await _dbContext.Database.BeginTransactionAsync();
                try
                {
                    // DELETE IF NOT EXISTS PROPERTY

                    if (activeProperty == null)
                    {
                        _dbSet.Remove(entity);
                    }
                    else // SET DELETED (TRUE) IF EXISTS AND SAVE
                    {
                        UpdatedAtProperty?.SetValue(entity, DateTime.Now);

                        activeProperty.SetValue(entity, false);

                        _dbSet.Update(entity);
                    }

                    await _dbContext.SaveChangesAsync();

                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();

                    throw;
                }
            }
            else
            {
                throw new ApplicationException("Object Not Found");
            }
        }

        public async Task Delete(List<T> entities)
        {
            using var transaction = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                foreach (var entity in entities)
                {
                    Type entityType = typeof(T);

                    PropertyInfo activeProperty = entityType.GetProperty("Active");

                    PropertyInfo UpdatedAtProperty = entityType.GetProperty("UpdatedAt");

                    // DELETE IF NOT EXISTS PROPERTY

                    if (activeProperty == null)
                    {
                        _dbSet.Remove(entity);
                    }
                    else // SET DELETED (TRUE) IF EXISTS AND SAVE
                    {
                        UpdatedAtProperty?.SetValue(entity, DateTime.Now);

                        activeProperty.SetValue(entity, false);

                        _dbSet.Update(entity);
                    }

                    await _dbContext.SaveChangesAsync();
                }

                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();

                throw;
            }
        }
    }
}
