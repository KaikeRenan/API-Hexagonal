using Api_Hexagonal.Entities;
using Api_Hexagonal.Interfaces.IRepositories;
using Api_Hexagonal.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Api_Hexagonal.Infrastructure.Repositories
{
    public class CursoRepository : BaseRepository<Curso>, ICursoRepository
    {
        public CursoRepository(Context context) : base(context) { }

        public List<Curso> GetAll()
        {
            return _dbSet
                .Include(c => c.Alunos)
                .ToList();
        }

        public Curso? GetById(Guid Id)
        {
            return _dbSet
                .Include(c => c.Alunos)
                .FirstOrDefault(c => c.Id == Id);
        }
    }
}
