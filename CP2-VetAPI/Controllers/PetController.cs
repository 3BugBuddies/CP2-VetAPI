using CP2_VetApi.Data;
using CP2_VetApi.Models;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult ListarTodos()
        {
            try
            {
                var resultado = _context.Pet.ToList();

                if (!resultado.Any())
                {
                    return NoContent();
                }

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Listar um Pet",
            Description = "Metodos resposável por listar/buscar 1 Pet da base de dados"
        )]
        public IActionResult ListarUm(int id)
        {
            try
            {
                var resultado = _context.Pet.FirstOrDefault(x => x.Id == id);

                if (resultado is null)
                {
                    return NotFound("Pet não encontrado.");
                }
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        //Tem que montar mais 1 metodo Get

        [HttpPost]
        [SwaggerOperation(
            Summary = "Adicionar Pet",
            Description = "Metodos resposável por Adicionar Pet na base de dados"
        )]
        public IActionResult CriarPet(PetEntity model)
        {
            try
            {
                _context.Pet.Add(model);
                _context.SaveChanges();

                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [SwaggerOperation(
            Summary = "Editar Pet",
            Description = "Metodos resposável por Editar Pet na base de dados"
        )]
        public IActionResult AtualizarPet(int id, PetEntity model)
        {
            try
            {
                var resultado = _context.Pet.FirstOrDefault(x => x.Id == id);

                if (resultado is null)
                {
                    return NotFound("Pet não encontrado.");
                }
                resultado.Nome = model.Nome;
                resultado.Idade = model.Idade;
                resultado.Raca = model.Raca;

                _context.Pet.Update(resultado);
                _context.SaveChanges();

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Deletar Pet",
            Description = "Metodos resposável por Deletar Pet da base de dados"
        )]
        public IActionResult Remover(int id)
        {
            try
            {
                var resultado = _context.Pet.FirstOrDefault(x => x.Id == id);
                if (resultado is null)
                {
                    return NotFound("Pet não encontrado.");
                }
                _context.Pet.Remove(resultado);
                _context.SaveChanges();
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
