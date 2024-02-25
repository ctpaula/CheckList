namespace CheckList.Domain.Interfaces.Services
{
    public  interface IPerguntaService
    {
        Task<Pergunta> GetById(int id);
        Task<List<Pergunta>> GetAll();
    }
}
