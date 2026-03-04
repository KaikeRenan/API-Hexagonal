using Api_Hexagonal.DTOs.CursoDTOs;
using Api_Hexagonal.Entities;

namespace Api_Hexagonal.Interfaces.IServices
{
    public interface ICursoService
    {
        public void CreateCurso(CreateCursoDTO curso);
        public Curso GetById(Guid id);
        public List<Curso> ListCursos();
        public void UpdateCurso(Guid id, UpdateCursoDTO curso);
        public void DeleteCurso(Guid id);
    }
}