using CP2_VetApi.Data;
using CP2_VetApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CP2_VetApi.Services
{
    public class TutorService : ITutorService
    {
        private readonly ApplicationContext _context;

        public TutorService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<TutorEntity>> ListarTodosAsync()
        {
            return await _context.Tutor.ToListAsync();
        }

        public async Task<TutorEntity?> ListarPorIdAsync(int id)
        {
            return await _context.Tutor.FindAsync(id);
        }

        public async Task<TutorEntity?> ListarPorTelefoneAsync(string telefone)
        {
            var telefoneFormatado = telefone.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
            return await _context.Tutor.Where(t => t.Telefone == telefoneFormatado).FirstOrDefaultAsync();
        }

        public async Task<TutorEntity> CriarAsync(TutorEntity entity)
        {
            entity.Telefone = entity.Telefone.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");

            _context.Tutor.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<TutorEntity?> AtualizarAsync(int id, TutorEntity entity)
        {
            var tutorExistente = await _context.Tutor.FindAsync(id);

            if (tutorExistente is null)
                return null;

            tutorExistente.Nome = entity.Nome;
            tutorExistente.Email = entity.Email;
            tutorExistente.Telefone = entity.Telefone;

            _context.Tutor.Update(tutorExistente);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<TutorEntity?> RemoverAsync(int id)
        {
            var entity = await _context.Tutor.FindAsync(id);

            if (entity is null)
                return null;

            _context.Tutor.Remove(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
