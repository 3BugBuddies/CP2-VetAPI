using CP2_VetApi.Data;
using CP2_VetApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace CP2_VetApi.Controllers
{
    [Route("api/tutor")]
    [ApiController]
    public class TutorController : ControllerBase
    {

        private readonly ApplicationContext _context;

        public TutorController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        [SwaggerOperation(
            Summary = "Listar todos os Tutores",
            Description = "Metodo resposável por listar todos os Tutores da base de dados"
        )]
        public async Task<IActionResult> ListarTodos()
        {
            var resultado = await _context.Tutor.ToListAsync();
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
            var resultado = await _context.Tutor.FindAsync(id);

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
            var telefoneFormatado = telefone.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");

            var resultado = await _context.Tutor.Where(t => t.Telefone == telefoneFormatado).FirstOrDefaultAsync();

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
            string telefoneFormatado = tutorEntity.Telefone.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");

            tutorEntity.Telefone = telefoneFormatado;

            _context.Tutor.Add(tutorEntity);
            await _context.SaveChangesAsync();

            return Ok(tutorEntity);
        }

        [HttpPut("{id}")]
        [SwaggerOperation(
            Summary = "Editar Tutor",
            Description = "Metodos resposável por Editar Tutor na base de dados"
        )]
        public async Task<IActionResult> AtualizarTutor(int id, TutorEntity tutorEntity)
        {
            var tutorExists = await _context.Tutor.FindAsync(id);

            if (tutorExists is not null)
            {
                tutorExists.Nome = tutorEntity.Nome;
                tutorExists.Email = tutorEntity.Email;
                tutorExists.Telefone = tutorEntity.Telefone;

                _context.Tutor.Update(tutorExists);
                await _context.SaveChangesAsync();

                return Ok(tutorEntity);
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Deletar Tutor",
            Description = "Metodos resposável por Deletar Tutor da base de dados"
        )]
        public async Task<IActionResult> Remover(int id)
        {
            var tutorEntity = await _context.Tutor.FindAsync(id);
            if (tutorEntity is null)
            {
                return NotFound();
            }

            _context.Tutor.Remove(tutorEntity);
            await _context.SaveChangesAsync();

            return Ok(tutorEntity);
        }
    }
}
