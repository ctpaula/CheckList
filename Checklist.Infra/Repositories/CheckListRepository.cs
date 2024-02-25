using CheckList.Domain;
using CheckList.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Utils.SimpleExtensions;

namespace Checklist.Infra.Repositories
{
    public class CheckListRepository : RepositoryBase<CheckListBody>, ICheckListRepository
    {
        protected CheckListRepository(RDbContext context) : base(context)
        {
        }
        public async Task<CheckListBody> GetById(int id)
        {
            return await _dbContext.CheckListBody.SingleOrDefaultAsync(x => x.CheckListBodyId == id) ??
                throw new ExceptionExtension("CheckList não encontrado.");
        }

        public async Task<CheckListBody> GetWithItemsById(int id) {
            return await _dbContext.CheckListBody
                .Include(x => x.CheckListItems)
                .SingleOrDefaultAsync(x => x.CheckListBodyId == id) ??
                throw new ExceptionExtension("CheckList não encontrado.");
        }

    }
}
