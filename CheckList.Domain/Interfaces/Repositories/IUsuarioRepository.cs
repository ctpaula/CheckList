namespace CheckList.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository : IRepositoryBase<Usuario>
    {
        Task<Usuario> GetById(int id);
        Task<Usuario> GetByMatricula(int matricula, bool supervisor = false);
    }
}
