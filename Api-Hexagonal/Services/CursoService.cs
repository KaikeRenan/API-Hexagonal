using Api_Hexagonal.DTOs.CursoDTOs;
using Api_Hexagonal.Entities;
using Api_Hexagonal.Interfaces.IRepositories;
using Api_Hexagonal.Interfaces.IServices;

namespace Api_Hexagonal.Services
{
    public class CursoService : ICursoService
    {
        private readonly ICursoRepository _repository;

        public CursoService(ICursoRepository repository)
        {
            _repository = repository;
        }
        public void CreateCurso(CreateCursoDTO cursoDTO)
        {
            try
            {
                Curso newCurso = new Curso();

                newCurso.Id = Guid.NewGuid();
                newCurso.CreatedAt = DateTime.UtcNow;
                newCurso.Name = cursoDTO.Name;
                newCurso.Description = cursoDTO.Description;

                _repository.Create(newCurso);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Curso GetById(Guid Id)
        {
            try
            {
                Curso curso = _repository.GetById(Id);

                if (curso == null)
                {
                    throw new Exception("Curso não encontrado");
                }

                return curso;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Curso> ListCursos()
        {
            List<Curso> list = _repository.GetAll();
            return list;
        }

        public void UpdateCurso(Guid Id, UpdateCursoDTO cursoDTO)
        {
            try
            {
                Curso updateCurso = _repository.GetById(Id);

                updateCurso.Name = cursoDTO.Name;
                updateCurso.Description = cursoDTO.Description;

                _repository.Update(updateCurso);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteCurso(Guid Id)
        {
            Curso curso = _repository.GetById(Id);

            if (curso == null)
            {
                throw new Exception("Curso não encontrado");
            }

            _repository.Delete(curso);
        }
    }
}
