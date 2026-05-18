using CP2_VetApi.Models;
using CP2_VetApi.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CP2_VetApi.Controllers
{
    [Route("api/tutor")]
    [ApiController]
    public class TutorController : ControllerBase
    {
        private readonly TutorService _tutorService;

        public TutorController(TutorService tutorService)
        {
            _tutorService = tutorService;
        }

        [HttpGet]
        [SwaggerOperation(
            Summary = "Listar todos os Tutores",
            Description = "Metodo resposável por listar todos os Tutores da base de dados"
        )]
        public async Task<IActionResult> ListarTodos()
        {
            var resultado = await _tutorService.ListarTodosAsync();
            return Ok(resultado);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Listar um Tutor",
            Description = "Metodo resposável por listar/buscar um Tutor da base de dados"
        )]
        [SwaggerResponse(statusCode: 200, description: "Tutor encontrado com sucesso", type: typeof(TutorEntity))]
        [SwaggerResponse(statusCode: 404, description: "Tutor não encontrado")]
        [SwaggerResponse(statusCode: 400, description: "Requisição inválida")]
        public async Task<IActionResult> ListarUm(int id)
        {
            var resultado = await _tutorService.ListarPorIdAsync(id);

            if (resultado is null)
            {
                return NotFound("Tutor não encontrado.");
            }

            return Ok(resultado);
        }

        [HttpGet("buscar/{telefone}")]
        [SwaggerOperation(
            Summary = "Lista tutor por telefone",
            Description = "Metodo resposável por listar/buscar um Tutor pelo telefone"
        )]
        public async Task<IActionResult> ListarPorTelefone(string telefone)
        {
            var resultado = await _tutorService.ListarPorTelefoneAsync(telefone);

            if (resultado == null)
            {
                return NotFound("Nenhum tutor possui o número informado");
            }

            return Ok(resultado);
        }

        [HttpPost]
        [SwaggerOperation(
            Summary = "Adicionar Tutor",
            Description = "Metodo resposável por Adicionar Tutor na base de dados"
        )]
        public async Task<IActionResult> CriarTutor(TutorEntity tutorEntity)
        {
            var resultado = await _tutorService.CriarAsync(tutorEntity);
            return Ok(resultado);
        }

        [HttpPut("{id}")]
        [SwaggerOperation(
            Summary = "Editar Tutor",
            Description = "Metodos resposável por Editar Tutor na base de dados"
        )]
        public async Task<IActionResult> AtualizarTutor(int id, TutorEntity tutorEntity)
        {
            var resultado = await _tutorService.AtualizarAsync(id, tutorEntity);

            if (resultado is null)
            {
                return NotFound();
            }

            return Ok(resultado);
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Deletar Tutor",
            Description = "Metodos resposável por Deletar Tutor da base de dados"
        )]
        public async Task<IActionResult> Remover(int id)
        {
            var resultado = await _tutorService.RemoverAsync(id);

            if (resultado is null)
            {
                return NotFound();
            }

            return Ok(resultado);
        }
    }
}
