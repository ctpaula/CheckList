using CheckList.Domain.DTO;

namespace CheckList.Domain.Interfaces.Repositories
{
    public interface ICheckListRepository : IRepositoryBase<CheckListBody>
    {
        Task<CheckListBody> GetById(int id);
        Task<CheckListBody> GetWithItemsById(int id);
    }
}
