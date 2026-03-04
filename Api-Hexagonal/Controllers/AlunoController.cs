using Api_Hexagonal.DTOs.AlunoDTOs;
using Api_Hexagonal.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Api_Hexagonal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoService _service;

        public AlunoController(IAlunoService service)
        {
            _service = service;
        }

        // Post
        [HttpPost]
        public IActionResult CreateAluno([FromBody] CreateAlunoDTO aluno)
        {
            try
            {
                _service.CreateAluno(aluno);
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
                var alunos = _service.ListAlunos();
                return Ok(alunos);
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
                ResponseAlunoDTO aluno = _service.GetById(Id);

                if (aluno == null)
                {
                    return NotFound();
                }

                return Ok(aluno);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT
        [HttpPut("{Id}")]
        public IActionResult UpdateAluno(Guid Id, [FromBody] UpdateAlunoDTO aluno)
        {
            try
            {
                _service.UpdateAluno(Id, aluno);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{Id}")]
        public IActionResult DeleteAluno(Guid Id) 
        {
            try
            {
                _service.DeleteAluno(Id);
                return Ok();
            }
            catch (Exception ex) 
            { 
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Matricular/{alunoId}/{cursoId}")]
        public IActionResult Matricular(Guid alunoId, Guid cursoId)
        {
            try
            {
                _service.Matricular(alunoId, cursoId);
                return Ok("Aluno matriculado com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
