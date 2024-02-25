using CheckList.Domain.Interfaces.Repositories;
using CheckList.Domain.Interfaces.Services;
using Microsoft.EntityFrameworkCore;

namespace CheckList.Domain
{
    public class PerguntaService : IPerguntaService
    {
        private readonly IPerguntaRepository _perguntaRepository;

        public PerguntaService(IPerguntaRepository perguntaRep)
        {
            _perguntaRepository = perguntaRep;
        }

        public async Task<Pergunta> GetById(int id)
        {
            return await _perguntaRepository.GetById(id);
        }

        public async Task<List<Pergunta>> GetAll()
        {
            return await _perguntaRepository.Query().ToListAsync();
        }
    }
}
