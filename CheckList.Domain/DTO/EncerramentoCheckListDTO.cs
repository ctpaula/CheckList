namespace CheckList.Domain.DTO
{
    public class EncerramentoCheckListDTO : PadraoDTO
    {
        public bool Completado { get; set; } = false;
        public string? Mensagem { get; set; }

        public EncerramentoCheckListDTO(bool erro, string? textoErro):base(erro, textoErro) { }

        public EncerramentoCheckListDTO() {
            this.Completado = true;
            this.Mensagem = "Encerramento efetuado com sucesso";
        }
    }
}
