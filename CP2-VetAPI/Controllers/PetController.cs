using CP2_VetApi.Data;
using CP2_VetApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace CP2_VetApi.Controllers
{
    [Route("api/pet")]
    [ApiController]
    public class PetController : ControllerBase
    {

        private readonly ApplicationContext _context;

        public PetController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        [SwaggerOperation(
            Summary = "Listar todos os Pet",
            Description = "Metodos resposável por listar todos os Pets da base de dados"
        )]
        public async Task<IActionResult> ListarTodos()
        {
            var resultado = await _context.Pet.ToListAsync();

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

            var resultado = await _context.Pet.FindAsync(id);

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
            var resultado = await _context.Pet.Where(e => e.Especie == especie).ToListAsync();

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
            _context.Pet.Add(entity);
            await _context.SaveChangesAsync();

            return Ok(entity);

        }

        [HttpPut("{id}")]
        [SwaggerOperation(
            Summary = "Editar Pet",
            Description = "Metodos resposável por Editar Pet na base de dados"
        )]
        public async Task<IActionResult> AtualizarPet(int id, PetEntity petEntity)
        {
            var petExists = await _context.Pet.FindAsync(id);

            if (petExists is not null)
            {
                petExists.Nome = petEntity.Nome;
                petExists.Raca = petEntity.Raca;
                petExists.Especie = petEntity.Especie;
                petExists.Idade = petEntity.Idade;


                _context.Pet.Update(petExists);
                await _context.SaveChangesAsync();

                return Ok(petEntity);
            }

            return NotFound();

        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Deletar Pet",
            Description = "Metodos resposável por Deletar Pet da base de dados"
        )]
        public async Task<IActionResult> Remover(int id)
        {
            var petEntity = await _context.Pet.FindAsync(id);

            if (petEntity is null)
            {
                return NotFound();
            }

            _context.Pet.Remove(petEntity);
            await _context.SaveChangesAsync();

            return Ok(petEntity);

        }
    }
}
