using CheckList.Domain.Commands;
using System.ComponentModel.DataAnnotations;

namespace CheckList.Domain
{
    public partial class CheckListBody
    {
        public int CheckListBodyId { get; set; }

        [Required(ErrorMessage = "Executor obrigatório.")]
        public int ExecutorId { get; set; }
        public Usuario? Executor { get; set; }

        public int SupervisorId { get; set; }
        public Usuario? Supervisor { get; set; }

        public DateTime? DataInicioExecucao { get; set; }
        
        public DateTime? DataFimExecucao { get; set; }

        public List<CheckListItem>? CheckListItems { get; set; }

        public CheckListBody(int executorId)
        {
            ExecutorId = executorId;
            DataInicioExecucao = DateTime.Now;
        }

        public void Atualizar(ExecucaoCheckListCMM command)
        {
            if (command.ItensCheckList == null) return;

            if (this.CheckListItems == null)
                this.CheckListItems = command.ItensCheckList.Select(x => new CheckListItem(x, this)).ToList();
            else
            {
                var itensUpdate = command.ItensCheckList
                    .Where(i => this.CheckListItems.Any(ci => ci.CheckListItemId == i.CheckListItemId))
                    .ToList();

                foreach (var item in itensUpdate)
                {
                    var itemBd = this.CheckListItems.First(i => i.CheckListItemId == item.CheckListItemId);
                    itemBd.Atualizar(item);
                }

                var itensNovos = command.ItensCheckList
                    .Where(i => !this.CheckListItems.Any(ci => ci.CheckListItemId == i.CheckListItemId))
                    .ToList();

                this.CheckListItems.AddRange(itensNovos.Select(x => new CheckListItem(x, this)));
            }

            return;
        }

        public void Encerrar(int SupervisorId)
        {
            this.SupervisorId = SupervisorId;
            this.DataFimExecucao = DataFimExecucao;
        }
    }
}
