using ConnectSea.Crud.Domain.Dto.Results;
using ConnectSea.Crud.Domain.Entity;
using ConnectSea.Crud.Domain.Repository;
using ConnectSea.Crud.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ConnectSea.Crud.Infra.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : BaseEntity
    {
        protected readonly DbCtx Db;

        public RepositoryBase(DbCtx context)
        {
            Db = context;
        }

        public async Task<PagedResult<T>> GetPagedAsync(int page, int pageSize, Expression<Func<T, object>> orderBy)
        {
            var query = Db.Set<T>()
                .AsNoTracking()
                .OrderBy(orderBy);

            var totalItems = await query.CountAsync();

            var data = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResult<T>
            {
                Data = data,
                TotalItems = totalItems,
                Page = page,
                PageSize = pageSize
            };
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Db.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await Db.Set<T>().FindAsync(id);
        }

        public async Task AddAsync(T obj)
        {
            await Db.Set<T>().AddAsync(obj);
        }

        public void Remove(T obj)
        {
            Db.Set<T>().Remove(obj);
        }

        public void Update(T obj)
        {
            Db.Set<T>().Update(obj);
        }

        public async Task SaveChangesAsync()
        {
            await Db.SaveChangesAsync();
        }
    }
}