using CheckList.Domain.Commands;
using System.ComponentModel.DataAnnotations;

namespace CheckList.Domain
{
    public partial class CheckListItem
    {
        public int CheckListItemId { get; set; }

        [Required(ErrorMessage = "Um item de Checklist deve obrigatoriamente corresponder a um CheckList existente.")]
        public int CheckListBodyId { get; set; }
        public CheckListBody? CheckListBody { get; set; }

        [Required(ErrorMessage = "Um item de Checklist deve obrigatoriamente responder a uma questão.")]
        public int PerguntaId { get; set; }
        public Pergunta? Pergunta { get; set; }

        public bool EstaChecado { get; set; } = false;
        public bool PassouCheck { get; set; } = false;

        public string? Observacao { get; set; }

        public CheckListItem() { }
        public CheckListItem(CheckListItemCMM itemCommand, CheckListBody body)
        {
            this.CheckListBodyId = body.CheckListBodyId;
            this.PerguntaId = itemCommand.PerguntaId;
            this.EstaChecado = itemCommand.EstaChecado;
            this.PassouCheck = itemCommand.PassouCheck;
            this.Observacao = itemCommand.Observacao;
        }

        public void Atualizar(CheckListItemCMM itemCommand)
        {
            this.PassouCheck = itemCommand.PassouCheck;
            this.EstaChecado = itemCommand.EstaChecado;
            this.Observacao = itemCommand.Observacao;
        }
    }
}
