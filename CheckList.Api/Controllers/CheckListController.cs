using CheckList.Domain.Commands;
using CheckList.Domain.DTO;
using CheckList.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Utils.SimpleExtensions;

namespace CheckList.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CheckListController : Controller
    {
        private readonly ILogger<CheckListController> _logger;
        private ICheckListService _service;

        public CheckListController(ILogger<CheckListController> logger, ICheckListService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost(Name = "IniciarChecklist")]
        public async Task<InicioChecklistDTO> IniciarChecklist([FromBody] InicioCheckListCMM command)
        {
            try
            {
                return await _service.IniciarChecklist(command);
            }
            catch (Exception ex)
            {
                var erro = "Erro de sistema ao iniciar Checklist";
                _logger.LogError(erro, ex.Message, ex.StackTrace);
                return new InicioChecklistDTO(true, erro);
            }
        }

        [HttpPost(Name = "ExecutarChecklist")]
        public async Task<ExecucaoCheckListDTO> ExecutarChecklist([FromBody] ExecucaoCheckListCMM command)
        {
            try
            {
                return await _service.ExecutarCheckList(command);
            }
            catch(ExceptionExtension exe)
            {
                _logger.LogError(exe.MsgSistema, exe.Message, exe.StackTrace);
                return new ExecucaoCheckListDTO(true, exe.MsgSistema);
            }
            catch (Exception ex)
            {
                var erro = "Erro de sistema ao executar Checklist";
                _logger.LogError(erro, ex.Message, ex.StackTrace);
                return new ExecucaoCheckListDTO(true, erro);
            }
        }

        [HttpPost(Name = "EncerrarChecklist")]
        public async Task<EncerramentoCheckListDTO> EncerrarChecklist([FromBody] EncerramentoCheckListCMM command)
        {
            try
            {
                return await _service.EncerrarCheckList(command);
            }
            catch (ExceptionExtension exe)
            {
                _logger.LogError(exe.MsgSistema, exe.Message, exe.StackTrace);
                return new EncerramentoCheckListDTO(true, exe.MsgSistema);
            }
            catch (Exception ex)
            {
                var erro = "Erro de sistema ao encerrar Checklist";
                _logger.LogError(erro, ex.Message, ex.StackTrace);
                return new EncerramentoCheckListDTO(true, erro);
            }
        }
    }
}
