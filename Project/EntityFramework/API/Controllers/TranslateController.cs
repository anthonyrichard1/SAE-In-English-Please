using DTO;
using DTOToEntity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TranslateController : ControllerBase
    {
        private readonly IService<TranslateDTO> _service;
        private readonly ILogger<TranslateController> _logger;

        public TranslateController(IService<TranslateDTO> TranslateService, ILogger<TranslateController> logger)
        {
            _service = TranslateService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TranslateDTO>>> GetTranslates()
        {
            _logger.LogInformation("Getting Translates ");
            var Translates = await _service.Gets();
            return Ok(Translates);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<TranslateDTO>> GetTranslate(int id)
        {
            _logger.LogInformation("Getting a Translate with id {id}", id);
            var Translate = await _service.GetById(id);
            return Ok(Translate);
        }

        [HttpPut]
        public async Task<ActionResult<TranslateDTO>> UpdateTranslate([FromQuery] TranslateDTO Translate)
        {
            _logger.LogInformation("Updating a Translate with id : {id}", Translate.Id);
            var updatedTranslate = await _service.Update(Translate);
            return Ok(updatedTranslate);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TranslateDTO>> DeleteTranslate(int id)
        {
            _logger.LogInformation("Deleting a Translate with id : {id}", id);
            var Translate = await _service.Delete(id);
            return Ok(Translate);
        }

        [HttpPost]
        public async Task<ActionResult<TranslateDTO>> AddTranslate([FromQuery] TranslateDTO Translate)
        {
            _logger.LogInformation("Adding a Translate with id : {id}", Translate.Id);
            Translate.Id = _service.Gets().Result.Count() + 1;
            var newTranslate = await _service.Add(Translate);
            return Ok(newTranslate);
        }

    }
}
