using CP2_VetApi.Data;
using CP2_VetApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CP2_VetApi.Services
{
    public class PetService
    {
        private readonly ApplicationContext _context;
        private readonly MotorServiceClient _motorClient;

        public PetService(ApplicationContext context, MotorServiceClient motorClient)
        {
            _context = context;
            _motorClient = motorClient;
        }

        public async Task<List<PetEntity>> ListarTodosAsync()
        {
            return await _context.Pet.ToListAsync();
        }

        public async Task<PetEntity?> ListarPorIdAsync(int id)
        {
            return await _context.Pet.FindAsync(id);
        }

        public async Task<List<PetEntity>> ListarPorEspecieAsync(string especie)
        {
            return await _context.Pet.Where(e => e.Especie == especie).ToListAsync();
        }

        public async Task<PetEntity> CriarAsync(PetEntity entity)
        {
            _context.Pet.Add(entity);
            await _context.SaveChangesAsync();

            try { await _motorClient.InstanciarPlano(entity); } catch { }

            return entity;
        }

        public async Task<PetEntity?> AtualizarAsync(int id, PetEntity entity)
        {
            var petExistente = await _context.Pet.FindAsync(id);

            if (petExistente is null)
                return null;

            petExistente.Nome = entity.Nome;
            petExistente.Raca = entity.Raca;
            petExistente.Especie = entity.Especie;
            petExistente.Idade = entity.Idade;

            _context.Pet.Update(petExistente);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<PetEntity?> RemoverAsync(int id)
        {
            var entity = await _context.Pet.FindAsync(id);

            if (entity is null)
                return null;

            _context.Pet.Remove(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
