using Api_Hexagonal.Entities;

namespace Api_Hexagonal.Interfaces.IRepositories
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        public void Create(T entity);
        public T? GetById(Guid Id);
        public List<T> GetAll();
        public void Update(T entity);
        public void Delete(T entity);
    }
}
