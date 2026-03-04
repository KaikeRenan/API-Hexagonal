using Api_Hexagonal.Entities;
using Api_Hexagonal.Interfaces.IRepositories;
using Api_Hexagonal.Infrastructure.Data;

namespace Api_Hexagonal.Infrastructure.Repositories
{
    public class AlunoRepository : BaseRepository<Aluno>, IAlunoRepository 
    {
        public AlunoRepository(Context context) : base(context) { }

        public Aluno GetByEmail(string email)
        {
            return _dbSet.FirstOrDefault(aluno => aluno.Email == email);
        }

        public void Matricular(Guid Id, Guid cursoId) 
        {
            var aluno = _dbSet.Find(Id);

            aluno.CursoId = cursoId;

            _dbSet.Update(aluno);
            _context.SaveChanges();
        }
    }
}
