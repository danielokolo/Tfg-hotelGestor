
using Microsoft.EntityFrameworkCore;
using Tfg_hotelGestor.Contracts;
using Tfg_hotelGestor.Data;
using Tfg_hotelGestor.Entities;

namespace Tfg_hotelGestor.Services
{
    public class CrudServiceBase<T, TKey> : IGenericCRUD<T, TKey> where T : class
    {
        protected readonly HotelGestorDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public CrudServiceBase(HotelGestorDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<T> CreateAsync(T entity)
        {
            _dbSet.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(TKey id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null) return false;
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(TKey id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<T> UpdateAsync(TKey id, T entity)
        {
            var existing = await _context.Set<T>().FindAsync(id);
            if (existing == null) return default;

            var entry = _context.Entry(existing);
            var entityEntry = _context.Entry(entity);

            foreach (var prop in entry.Metadata.GetProperties().Where(p => !p.IsPrimaryKey()))
            {
                entry.Property(prop.Name).CurrentValue = entityEntry.Property(prop.Name).CurrentValue;
            }

            await _context.SaveChangesAsync();
            return existing;
        }

    }
}
