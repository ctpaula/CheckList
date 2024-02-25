namespace CheckList.Domain.DTO
{
    public class PerguntaDTO : PadraoDTO
    {
        public int PerguntaId { get; set; }
        public string? Questao { get; set; }
        public string? Parametro { get; set; }
        public PerguntaDTO(bool erro, string? textoErro) : base(erro, textoErro) { }
        public PerguntaDTO(Pergunta bdPergunta)
        {
            this.PerguntaId = bdPergunta.PerguntaId;
            this.Questao = bdPergunta.Questao;
            this.Parametro = bdPergunta.Parametro;
        }
    }
}
