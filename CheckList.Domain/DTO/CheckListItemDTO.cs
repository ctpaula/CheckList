namespace CheckList.Domain.DTO
{
    public class CheckListItemDTO
    {
        public int CheckListItemId { get; set; }
        public int CheckListBodyId { get; set; }
        public int PerguntaId { get; set; }
        public bool EstaChecado { get; set; } = false;
        public bool PassouCheck { get; set; } = false;
        public string? Observacao { get; set; }

        public CheckListItemDTO(CheckListItem bdItem)
        {
            this.CheckListBodyId = bdItem.CheckListBodyId;
            this.CheckListItemId = bdItem.CheckListItemId;
            this.EstaChecado = bdItem.EstaChecado;
            this.PassouCheck = bdItem.PassouCheck;
            this.Observacao = bdItem.Observacao;
        }
    }
}
