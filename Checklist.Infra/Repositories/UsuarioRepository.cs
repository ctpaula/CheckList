using CheckList.Domain;
using CheckList.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Utils.SimpleExtensions;

namespace Checklist.Infra.Repositories
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(RDbContext context) : base(context) { }

        public async Task<Usuario> GetById(int id)
        {
            return await _dbContext.Usuario.SingleOrDefaultAsync(p => p.UsuarioId == id) ??
                throw new ExceptionExtension("Executor não encontrado.");
        }

        public async Task<Usuario> GetByMatricula(int matricula, bool supervisor = false)
        {
            return await _dbContext.Usuario
                .SingleOrDefaultAsync(p => p.Matricula == matricula && p.SupervisorCheckList == supervisor) ??
                (supervisor ?
                    throw new ExceptionExtension("Supervisor não encontrado.") :
                    throw new ExceptionExtension("Executor não encontrado."));
        }
    }
}
