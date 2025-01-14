using FinancasPessoais.Authentication.Domain.Common;
using FinancasPessoais.Authentication.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FinancasPessoais.Authentication.Infra.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly FinancasPessoaisDbContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public BaseRepository(FinancasPessoaisDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<TEntity?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            var user = await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return user.Entity;
        }

        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }

        public void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
