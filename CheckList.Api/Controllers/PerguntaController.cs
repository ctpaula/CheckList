using CheckList.Domain;
using CheckList.Domain.DTO;
using CheckList.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace CheckList.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PerguntaController : ControllerBase
    {
        private readonly ILogger<PerguntaController> _logger;
        private IPerguntaService _service;

        public PerguntaController(ILogger<PerguntaController> logger, IPerguntaService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet("/GetById/{Id}")]
        public async Task<PerguntaDTO> GetById([FromQuery] int Id)
        {
            try
            {
                return new PerguntaDTO(await _service.GetById(Id));
            }
            catch (Exception ex)
            {
                var erro = "Erro de sistema ao pesquisar Peguntas";
                _logger.LogError(erro, ex.Message, ex.StackTrace);
                return new PerguntaDTO(true, erro);
            }
        }

        [HttpGet("/GetAll")]
        public async Task<List<PerguntaDTO>> GetAll()
        {
            try
            {
                var lista = await _service.GetAll();
                return lista.Select(x => new PerguntaDTO(x)).ToList();
            }
            catch (Exception ex)
            {
                var erro = "Erro de sistema ao pesquisar Peguntas";
                _logger.LogError(erro, ex.Message, ex.StackTrace);
                return new List<PerguntaDTO>();
            }
        }
    }
}