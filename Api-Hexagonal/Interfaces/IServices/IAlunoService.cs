using Api_Hexagonal.DTOs.AlunoDTOs;

namespace Api_Hexagonal.Interfaces.IServices
{
    public interface IAlunoService
    {
        public ResponseAlunoDTO CreateAluno(CreateAlunoDTO aluno);
        public ResponseAlunoDTO GetById(Guid Id);
        public List<ResponseAlunoDTO> ListAlunos();
        public ResponseAlunoDTO UpdateAluno(Guid Id, UpdateAlunoDTO aluno);
        public void DeleteAluno(Guid Id);

        //Curso
        public void Matricular(Guid Id, Guid cursoId);
    }
}
