using System.ComponentModel.DataAnnotations;

namespace CheckList.Domain
{
    public partial class Pergunta
    {
        public int PerguntaId { get; set; }
        public string? Questao { get; set; }
        public string? Parametro { get; set; }
    }
}