namespace CheckList.Domain.Interfaces.Repositories
{
    public interface IPerguntaRepository : IRepositoryBase<Pergunta>
    {
        Task<Pergunta> GetById(int id);
    }
}
