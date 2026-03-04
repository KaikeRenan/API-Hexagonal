using Api_Hexagonal.DTOs.AlunoDTOs;
using Api_Hexagonal.Entities;
using Api_Hexagonal.Interfaces.IRepositories;
using Api_Hexagonal.Interfaces.IServices;

namespace Api_Hexagonal.Services
{
    public class AlunoService : IAlunoService
    {
        private readonly IAlunoRepository _repository;
        private readonly ICursoRepository _repositoryCurso;

        public AlunoService(IAlunoRepository repository, ICursoRepository repositoryCurso)
        {
            _repository = repository;
            _repositoryCurso = repositoryCurso;
        }

        public ResponseAlunoDTO CreateAluno(CreateAlunoDTO alunoDTO)
        {
            try
            {
                Aluno newAluno = new Aluno();

                // Presença
                if (string.IsNullOrWhiteSpace(alunoDTO.FirstName))
                {
                    throw new Exception("FirstName é obrigatório");
                }

                // Extensão
                if (alunoDTO.FirstName.Length > 50)
                {
                    throw new Exception("FirstName é maior que 50 caracteres");
                }

                // Domínio
                if (string.IsNullOrWhiteSpace(alunoDTO.Email) || !alunoDTO.Email.EndsWith("@faculdade.edu"))
                {
                    throw new Exception("Email deve obrigatoriamente terminar com @faculdade.edu");
                }

                // Unicidade
                var verificationEmail = _repository.GetByEmail(alunoDTO.Email);

                if (verificationEmail != null)
                    throw new Exception("Este Email pertence a outro aluno");

                newAluno.Id = Guid.NewGuid();
                newAluno.CreatedAt = DateTime.Now;
                newAluno.FirstName = alunoDTO.FirstName;
                newAluno.LastName = alunoDTO.LastName;
                newAluno.Email = alunoDTO.Email;
                newAluno.Password = alunoDTO.Password;

                _repository.Create(newAluno);

                return new ResponseAlunoDTO
                {
                    Id = newAluno.Id,
                    FirstName = newAluno.FirstName,
                    LastName = newAluno.LastName,
                    Email = newAluno.Email
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ResponseAlunoDTO GetById(Guid Id)
        {
            try
            {
                Aluno aluno = _repository.GetById(Id);

                if (aluno == null)
                {
                    throw new Exception("Aluno não encontrado");
                }

                return new ResponseAlunoDTO
                {
                    Id = aluno.Id,
                    FirstName = aluno.FirstName,
                    LastName = aluno.LastName,
                    Email = aluno.Email
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<ResponseAlunoDTO> ListAlunos()
        {
            try
            {
                List<Aluno> list = _repository.GetAll();
                return list.Select(aluno => new ResponseAlunoDTO
                {
                    Id = aluno.Id,
                    FirstName = aluno.FirstName,
                    LastName = aluno.LastName,
                    Email = aluno.Email
                }).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ResponseAlunoDTO UpdateAluno(Guid Id, UpdateAlunoDTO alunoDTO)
        {
            try
            {
                Aluno updateAluno = _repository.GetById(Id);

                if (updateAluno == null)
                {
                    throw new Exception("Aluno não encontrado");
                }

                // Presença 
                if (string.IsNullOrWhiteSpace(alunoDTO.FirstName))
                {
                    throw new Exception("FirstName é obrigatório");
                }

                // Extensão 
                if (alunoDTO.FirstName.Length > 50)
                {
                    throw new Exception("FirstName é maior que 50 caracteres");
                }

                // Domínio 
                if (string.IsNullOrWhiteSpace(alunoDTO.Email) || !alunoDTO.Email.EndsWith("@faculdade.edu"))
                {
                    throw new Exception("Email deve obrigatoriamente terminar com @faculdade.edu");
                }

                // Unicidade
                //var verificationEmail = _repository.GetByEmail(alunoDTO.Email);

                //if (verificationEmail != null)
                //    throw new Exception("Este Email pertence a outro aluno");

                updateAluno.FirstName = alunoDTO.FirstName;
                updateAluno.LastName = alunoDTO.LastName;
                updateAluno.Email = alunoDTO.Email;
                updateAluno.Password = alunoDTO.Password;

                _repository.Update(updateAluno);

                return new ResponseAlunoDTO
                {
                    Id = updateAluno.Id,
                    FirstName = updateAluno.FirstName,
                    LastName = updateAluno.LastName,
                    Email = updateAluno.Email
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteAluno(Guid Id)
        {
            Aluno aluno = _repository.GetById(Id);

            if (aluno == null)
            {
                throw new Exception("Aluno não encontrado");
            }

            _repository.Delete(aluno);
        }

        //Curso
        public void Matricular(Guid alunoId, Guid cursoId)
        {
            Aluno aluno = _repository.GetById(alunoId);
            if (aluno == null)
                throw new Exception("Aluno não encontrado");

            var curso = _repositoryCurso.GetById(cursoId);
            if (curso == null)
                throw new Exception("Curso não encontrado");

            _repository.Matricular(alunoId, cursoId);
        }
    }
}
