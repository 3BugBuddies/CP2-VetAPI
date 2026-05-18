using CP2_VetApi.Models;

namespace CP2_VetApi.Services
{
    public class MotorServiceClient
    {
        private readonly HttpClient _client;

        public MotorServiceClient(HttpClient client)
        {
            _client = client;
        }

        // G1 — animal cadastrado
        public async Task InstanciarPlano(PetEntity pet)
        {
            var payload = new
            {
                vetapiAnimalId = pet.Id,
                especie = pet.Especie,
                idadeAnos = pet.Idade
            };
            await _client.PostAsJsonAsync("/api/motor/planos/instanciar", payload);
        }

        // G2 — consulta realizada (a implementar quando ConsultaService existir)
        public async Task RecalcularScore(int animalId, int consultaId)
        {
            var payload = new
            {
                vetapiAnimalId = animalId,
                vetapiConsultaId = consultaId,
                motivo = "CONSULTA_REALIZADA"
            };
            await _client.PostAsJsonAsync("/api/motor/scores/recalcular", payload);
        }

        // G3 — cirurgia realizada (a implementar quando ConsultaService existir)
        public async Task InstanciarPlanoPosCircurgico(int animalId, int consultaId)
        {
            var payload = new
            {
                vetapiAnimalId = animalId,
                vetapiConsultaId = consultaId,
                dataRealizacao = DateTime.UtcNow
            };
            await _client.PostAsJsonAsync("/api/motor/planos/pos-cirurgico", payload);
        }
    }
}
