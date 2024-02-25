namespace CheckList.Domain.Commands
{
    public class ExecucaoCheckListCMM
    {
        public int CheckListBodyId { get; set; }
        public int ExecutorId { get; set; }
        public List<CheckListItemCMM>? ItensCheckList { get; set; }
    }
}
