using CP2_VetApi.Models;
using CP2_VetApi.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CP2_VetApi.Controllers
{
    [Route("api/pet")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly PetService _petService;

        public PetController(PetService petService)
        {
            _petService = petService;
        }

        [HttpGet]
        [SwaggerOperation(
            Summary = "Listar todos os Pet",
            Description = "Metodos resposável por listar todos os Pets da base de dados"
        )]
        public async Task<IActionResult> ListarTodos()
        {
            var resultado = await _petService.ListarTodosAsync();

            if (resultado == null)
            {
                return NoContent();
            }
            return Ok(resultado);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Listar um Pet",
            Description = "Metodos resposável por listar/buscar um Pet da base de dados"
        )]
        [SwaggerResponse(statusCode: 200, description: "Pet atualizado com sucesso", type: typeof(PetEntity))]
        [SwaggerResponse(statusCode: 404, description: "Pet não encontrado")]
        [SwaggerResponse(statusCode: 400, description: "Requisição inválida")]
        public async Task<IActionResult> ListarUm(int id)
        {
            var resultado = await _petService.ListarPorIdAsync(id);

            if (resultado == null)
            {
                return NotFound("Pet não encontrado.");
            }

            return Ok(resultado);
        }

        [HttpGet("buscar/{especie}")]
        [SwaggerOperation(
            Summary = "Listar todos os Pet por Espécie",
            Description = "Metodos resposável por listar todos os Pets de uma determinada espécie da base de dados"
        )]
        public async Task<IActionResult> ListarTodosPorEspecie(string especie)
        {
            var resultado = await _petService.ListarPorEspecieAsync(especie);

            if (!resultado.Any())
            {
                return NotFound("Não existe nenhum animal da espécie informada");
            }

            return Ok(resultado);
        }

        [HttpPost]
        [SwaggerOperation(
            Summary = "Adicionar Pet",
            Description = "Metodos resposável por Adicionar Pet na base de dados"
        )]
        public async Task<IActionResult> CriarPet(PetEntity entity)
        {
            var resultado = await _petService.CriarAsync(entity);
            return Ok(resultado);
        }

        [HttpPut("{id}")]
        [SwaggerOperation(
            Summary = "Editar Pet",
            Description = "Metodos resposável por Editar Pet na base de dados"
        )]
        public async Task<IActionResult> AtualizarPet(int id, PetEntity petEntity)
        {
            var resultado = await _petService.AtualizarAsync(id, petEntity);

            if (resultado is null)
            {
                return NotFound();
            }

            return Ok(resultado);
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Deletar Pet",
            Description = "Metodos resposável por Deletar Pet da base de dados"
        )]
        public async Task<IActionResult> Remover(int id)
        {
            var resultado = await _petService.RemoverAsync(id);

            if (resultado is null)
            {
                return NotFound();
            }

            return Ok(resultado);
        }
    }
}
