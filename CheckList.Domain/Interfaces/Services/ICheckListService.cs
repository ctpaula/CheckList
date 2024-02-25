using CheckList.Domain.Commands;
using CheckList.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckList.Domain.Interfaces.Services
{
    public interface ICheckListService
    {
        Task<InicioChecklistDTO> IniciarChecklist(InicioCheckListCMM command);
        Task<ExecucaoCheckListDTO> ExecutarCheckList(ExecucaoCheckListCMM command);
        Task<EncerramentoCheckListDTO> EncerrarCheckList(EncerramentoCheckListCMM command);
    }
}
