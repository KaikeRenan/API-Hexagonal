using Api_Hexagonal.Entities;
using Api_Hexagonal.Interfaces.IRepositories;
using Api_Hexagonal.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Api_Hexagonal.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity 
    {
        public readonly Context _context;
        public readonly DbSet<T> _dbSet;

        public BaseRepository(Context context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public void Create(T entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public T? GetById(Guid Id)
        {
            return _dbSet.FirstOrDefault(entity => entity.Id == Id && entity.RemovedAt == null);
        }

        public List<T> GetAll()
        {
            return _dbSet.Where(entity => entity.RemovedAt == null).ToList();
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            entity.RemovedAt = DateTime.Now;
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }
    }
}
