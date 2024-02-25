using CheckList.Domain.Commands;
using CheckList.Domain.DTO;
using CheckList.Domain.Interfaces.Repositories;
using CheckList.Domain.Interfaces.Services;
using Utils.SimpleExtensions;

namespace CheckList.Domain.Services
{
    public class CheckListService : ICheckListService
    {
        private ICheckListRepository _checkListRepository;
        private ICheckListItemRepository _checkListItemRepository;
        private IUsuarioRepository _executorRepository;

        public CheckListService(ICheckListRepository checkListRepository, 
            IUsuarioRepository executorRepository,
            ICheckListItemRepository checkListItemRepository)
        {
            _checkListRepository = checkListRepository;
            _executorRepository = executorRepository;
            _checkListItemRepository = checkListItemRepository;
        }

        public async Task<InicioChecklistDTO> IniciarChecklist(InicioCheckListCMM command)
        {
            var executor = await _executorRepository.GetByMatricula(command.MatriculaExecutor);

            if(executor == null)
            {
                return new InicioChecklistDTO(true, "Executor não encontrado.");
            }

            var novoCheck = new CheckListBody(executor.UsuarioId);

            var checkGravado = await _checkListRepository.Add(novoCheck);

            return new InicioChecklistDTO(checkGravado);
        }

        public async Task<ExecucaoCheckListDTO> ExecutarCheckList(ExecucaoCheckListCMM command)
        {
            var executor = await _executorRepository.GetById(command.ExecutorId);

            var checkListBody = await _checkListRepository.GetWithItemsById(command.CheckListBodyId);

            if (executor.UsuarioId != checkListBody.ExecutorId) 
                throw new ExceptionExtension("Executor enviado não confere com executor do CheckList.");

            if (command.ItensCheckList == null) throw new ExceptionExtension("Não há itens para atualizar.");

            checkListBody.Atualizar(command);
            if(checkListBody.CheckListItems == null) throw new ExceptionExtension("Nenhum item novo ou atualizado.");

            foreach (var item in checkListBody.CheckListItems)
            {
                if (item.CheckListItemId == 0) await _checkListItemRepository.Add(item);
                else await _checkListItemRepository.Update(item);
            }

            return new ExecucaoCheckListDTO(checkListBody);
        }

        public async Task<EncerramentoCheckListDTO> EncerrarCheckList(EncerramentoCheckListCMM command)
        {
            var supervisor = await _executorRepository.GetByMatricula(command.MatriculaSupervisor, true);

            var checkListBody = await _checkListRepository.GetById(command.CheckListBodyId);

            checkListBody.Encerrar(supervisor.UsuarioId);

            await _checkListRepository.Update(checkListBody);

            return new EncerramentoCheckListDTO();
        }
    }
}
