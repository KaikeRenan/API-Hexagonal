using Api_Hexagonal.DTOs.CursoDTOs;
using Api_Hexagonal.Entities;
using Api_Hexagonal.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Api_Hexagonal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CursoController : ControllerBase
    {
        private readonly ICursoService _service;

        public CursoController(ICursoService service)
        {
            _service = service;
        }

        // Post
        [HttpPost]
        public IActionResult CreateCurso([FromBody] CreateCursoDTO curso)
        {
            try
            {
                _service.CreateCurso(curso);
                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GetAll
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var cursos = _service.ListCursos();
                return Ok(cursos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GetById
        [HttpGet("{Id}")]
        public IActionResult GetById(Guid Id)
        {
            try
            {
                Curso curso = _service.GetById(Id);

                if (curso == null)
                {
                    return NotFound();
                }

                return Ok(curso);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT
        [HttpPut("{Id}")]
        public IActionResult UpdateCurso(Guid Id, [FromBody] UpdateCursoDTO curso)
        {
            try
            {
                _service.UpdateCurso(Id, curso);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{Id}")]
        public IActionResult DeleteCurso(Guid Id)
        {
            try
            {
                _service.DeleteCurso(Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
