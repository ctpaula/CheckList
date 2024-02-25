using Microsoft.EntityFrameworkCore;

namespace CheckList.Domain.Interfaces
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<T> Add(T entity);

        Task Update(T entity);

        Task BulkInsert(List<T> entities);

        Task BulkUpdate(List<T> entities);

        Task Delete(T entity);

        Task Delete(List<T> entities);

        DbSet<T> Query();
    }
}
