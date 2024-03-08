using DTO;
using DTOToEntity;
using Entities;
using Microsoft.AspNetCore.Mvc;
using StubbedContextLib;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LangueController : ControllerBase
    {
        private readonly IService<LangueDTO> _service;
        private readonly ILogger<LangueController> _logger;

        public LangueController(IService<LangueDTO> LangueService, ILogger<LangueController> logger)
        {
            _service = LangueService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LangueDTO>>> GetLangues()
        {
            _logger.LogInformation("Getting langues ");
            var groups = await _service.Gets();
            return Ok(groups);
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<LangueDTO>> GetLangue(string name)
        {
            _logger.LogInformation("Getting a langue with name {name}",name);
            var group = await _service.GetById(name);
            return Ok(group);
        }

        [HttpPut]
        public async Task<ActionResult<LangueDTO>> UpdateLangue([FromQuery]LangueDTO langue)
        {
            _logger.LogInformation("Updating a langue with name : {name}",langue.name);
            var updatedGroup = await _service.Update(langue);
            return Ok(updatedGroup);
        }

        [HttpPost]
        public async Task<ActionResult<LangueDTO>> AddLangue([FromQuery]LangueDTO langue)
        {
            _logger.LogInformation("Adding a langue with name : {name}",langue.name);
            if(langue.name == null)
            {
                return BadRequest("Name is required");
            }
            if(_service.Gets().Result.Any(l => l.name == langue.name))
            {
                return BadRequest("Name already exists");
            }
            var newGroup = await _service.Add(langue);
            return Ok(newGroup);
        }

        [HttpDelete("{name}")]
        public async Task<ActionResult<LangueDTO>> DeleteLangue(string name)
        {
            _logger.LogInformation("Deleting a langue with name : {name}",name);
            var group = await _service.Delete(name);
            return Ok(group);
        }

    }
}
