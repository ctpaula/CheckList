using CheckList.Domain.Interfaces.Repositories;
using CheckList.Domain.Interfaces.Services;

namespace CheckList.Domain
{
    public class PerguntaService : IPerguntaService
    {
        private readonly IPerguntaRepository _perguntaRepository;

        public PerguntaService(IPerguntaRepository perguntaRep)
        {
            _perguntaRepository = perguntaRep;
        }

        public async Task<Pergunta> SelectById(int id)
        {
            return await _perguntaRepository.GetById(id);
        }
    }
}
