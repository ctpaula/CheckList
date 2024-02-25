namespace CheckList.Domain.DTO
{
    public class EncerramentoCheckListDTO : PadraoDTO
    {
        public bool InicioCompletado { get; set; } = false;
        public string? Mensagem { get; set; }

        public EncerramentoCheckListDTO(bool erro, string? textoErro):base(erro, textoErro) { }

        public EncerramentoCheckListDTO() {
            this.InicioCompletado = true;
            this.Mensagem = "Encerramento efetuado com sucesso";
        }
    }
}
