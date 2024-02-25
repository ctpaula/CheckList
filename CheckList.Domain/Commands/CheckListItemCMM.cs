namespace CheckList.Domain.Commands
{
    public class CheckListItemCMM
    {
        public int? CheckListItemId { get; set; }
        public int PerguntaId { get; set; }
        public bool EstaChecado { get; set; }
        public bool PassouCheck { get; set; }
        public string? Observacao { get; set; }
    }
}
