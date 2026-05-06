using AspNet.API.Data;
using CP_dotNet.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CP_dotNet.Controllers
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
            Summary = "Listar todos os Tutors",
            Description = "Metodos resposável por listar todos os Tutores da base de dados"
        )]
        public IActionResult Get()
        {
            try
            {
                var resultado = _context.Tutor.ToList();

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

        [HttpGet]
        [SwaggerOperation(
            Summary = "Listar um Tutor",
            Description = "Metodos resposável por listar/buscar 1 Tutor da base de dados"
        )]
        public IActionResult Get(int id)
        {
            try
            {
                var resultado = _context.Tutor.FirstOrDefault(x => x.Id == id);

                if (resultado is null)
                {
                    return NotFound("Tutor não encontrado.");
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
            Summary = "Adicionar Tutor",
            Description = "Metodos resposável por Adicionar Tutor na base de dados"
        )]
        public IActionResult Post(TutorEntity model)
        {
            try
            {
                _context.Tutor.Add(model);
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
            Summary = "Editar Tutor",
            Description = "Metodos resposável por Editar Tutor na base de dados"
        )]
        public IActionResult Put(int id, TutorEntity model)
        {
            try
            {
                var resultado = _context.Tutor.FirstOrDefault(x => x.Id == id);

                if (resultado is null)
                {
                    return NotFound("Tutor não encontrado.");
                }
                resultado.Nome = model.Nome;
                resultado.Email = model.Email;
                resultado.Telefone = model.Telefone;

                _context.Tutor.Update(resultado);
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
            Summary = "Deletar Tutor",
            Description = "Metodos resposável por Deletar Tutor da base de dados"
        )]
        public IActionResult Delete(int id)
        {
            try
            {
                var resultado = _context.Tutor.FirstOrDefault(x => x.Id == id);
                if (resultado is null)
                {
                    return NotFound("Tutor não encontrado.");
                }
                _context.Tutor.Remove(resultado);
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
