using ConnectSea.Crud.Domain.Dto.Results;
using System.Linq.Expressions;

namespace ConnectSea.Crud.Domain.Repository
{
    public interface IRepositoryBase<T> where T : class
    {
        Task AddAsync(T obj);
        void Update(T obj);
        void Remove(T obj);
        Task SaveChangesAsync();
        Task<PagedResult<T>> GetPagedAsync(int page, int pageSize, Expression<Func<T, object>> orderBy);
        Task<T?> GetByIdAsync(int id);
    }
}
