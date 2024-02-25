namespace CheckList.Domain.Interfaces.Services
{
    public  interface IPerguntaService
    {
        Task<Pergunta> SelectById(int id);
    }
}
