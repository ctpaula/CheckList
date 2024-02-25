using CheckList.Domain.Commands;

namespace CheckList.Domain.DTO
{
    public class ExecucaoCheckListDTO: PadraoDTO
    {
        public int CheckListBodyId { get; set; }
        public int ExecutorId { get; set; }

        public List<CheckListItemDTO>? Itens { get; set; }

        public ExecucaoCheckListDTO(bool erro, string? textoErro) : base(erro, textoErro) { }

        public ExecucaoCheckListDTO(CheckListBody bdCheckList)
        {
            this.CheckListBodyId = bdCheckList.CheckListBodyId;
            this.ExecutorId = bdCheckList.ExecutorId;
            this.Itens = bdCheckList?.CheckListItems?.Select(x => new CheckListItemDTO(x)).ToList();
        }
    }
}
