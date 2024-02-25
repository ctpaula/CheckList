using CheckList.Domain;
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

        [HttpGet(Name = "GetById/{Id}")]
        public async Task<Pergunta> GetById([FromQuery] int Id)
        {
            try
            {
                return await _service.SelectById(Id);
            }
            catch (Exception ex)
            {
                _logger.LogError("Erro ao buscar Pergunta", ex.Message, ex.StackTrace);
                return null;
            }
        }
    }
}