using Api_Hexagonal.Entities;

namespace Api_Hexagonal.Interfaces.IRepositories
{
    public interface IAlunoRepository : IBaseRepository<Aluno>
    {
        //public void Create(Aluno aluno);
        //public Aluno GetById(Guid Id);
        //public List<Aluno> GetAll();
        //public void Update(Aluno aluno);
        //public void Delete(Aluno aluno);
        public Aluno GetByEmail(string email);
        public void Matricular(Guid Id, Guid cursoId);
    }
}
