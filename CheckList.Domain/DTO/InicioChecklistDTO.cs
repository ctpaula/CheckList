namespace CheckList.Domain.DTO
{
    public class InicioChecklistDTO : PadraoDTO
    {
        public bool InicioCompletado { get; set; } = false;
        public string? Mensagem { get; set; }

        public int CheckListBodyId { get; set; }
        public int ExecutorId { get; set; }
        public DateTime? DataInicioExecucao { get; set; }

        public InicioChecklistDTO(CheckListBody checkList) : base()
        {
            this.InicioCompletado = true;
            this.Mensagem = "Proceder com a validação de itens.";
            this.CheckListBodyId = checkList.CheckListBodyId;
            this.ExecutorId = checkList.ExecutorId;
            this.DataInicioExecucao = checkList.DataInicioExecucao;
        }

        public InicioChecklistDTO(bool erro, string? textoErro) : base(erro, textoErro) { }
    }
}
