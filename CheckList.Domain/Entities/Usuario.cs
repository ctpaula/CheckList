using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CheckList.Domain
{
    public partial class Usuario
    {
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "Matrícula obrigatória.")]
        [RegularExpression("[0-9]", ErrorMessage = "Matrícula Inválida.")]
        public int Matricula { get; set; }

        public string? Nome { get; set; }

        [RegularExpression("^([0-9a-zA-Z]+([_.-]?[0-9a-zA-Z]+)*@[0-9a-zA-Z]+[0-9,a-z,A-Z,.,-]*(.){1}[a-zA-Z]{2,4})+$", ErrorMessage = "E-mail inválido.")]
        public string? Email { get; set; }

        public bool SupervisorCheckList { get; set; }

        [ForeignKey("ExecutorId")]
        public ICollection<CheckListBody>? CheckListsExecutor { get; set; }

        [ForeignKey("SupervisorId")]
        public ICollection<CheckListBody>? CheckListsSupervisor { get; set; }
    }
}
