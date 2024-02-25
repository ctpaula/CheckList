using CheckList.Domain;
using CheckList.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Utils.SimpleExtensions;

namespace Checklist.Infra.Repositories
{
    public class PerguntaRepository : RepositoryBase<Pergunta>, IPerguntaRepository
    {
        public PerguntaRepository(RDbContext context) : base(context) {}

        public async Task<Pergunta> GetById(int id)
        {
            return await _dbContext.Pergunta.SingleOrDefaultAsync(p => p.PerguntaId == id) ??
                throw new ExceptionExtension("Pergunta não encontrada.");
        }
    }
}
