using DTO;
using DTOToEntity;
using Entities;
using Microsoft.AspNetCore.Mvc;
using StubbedContextLib;

namespace API.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
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
        public async Task<ActionResult<IEnumerable<LangueDTO>>> GetLangues(int index, int count)
        {
            try { 
            _logger.LogInformation("Getting langues ");
            var groups = await _service.Gets(index,count);
            return Ok(groups);
                }
            catch (Exception ex)
            {
                // Journaliser l'exception
                _logger.LogError(ex, "Une erreur s'est produite lors de la récupération des langues.");

                // Retourner une réponse d'erreur
                return StatusCode(400, ex.Message);
            }
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<LangueDTO>> GetLangue(string name)
        {
            try { 
            _logger.LogInformation("Getting a langue with name {name}",name);
            var group = await _service.GetById(name);
            return Ok(group);
                }
            catch (Exception ex)
            {
                // Journaliser l'exception
                _logger.LogError(ex, "Une erreur s'est produite lors de la récupération de la langue avec le nom {name}.", name);

                // Retourner une réponse d'erreur
                return StatusCode(400, ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<LangueDTO>> UpdateLangue([FromQuery]LangueDTO langue)
        {
            try
            {
                _logger.LogInformation("Updating a langue with name : {name}", langue.name);
                var updatedGroup = await _service.Update(langue);
                return Ok(updatedGroup);
            }
            catch (Exception ex)
            {
                // Journaliser l'exception
                _logger.LogError(ex, "Une erreur s'est produite lors de la mise à jour de la langue avec le nom {name}.", langue.name);

                // Retourner une réponse d'erreur
                return StatusCode(400, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<LangueDTO>> AddLangue([FromQuery]LangueDTO langue)
        {
            try
            {
                _logger.LogInformation("Adding a langue with name : {name}", langue.name);
                if (langue.name == null)
                {
                    return BadRequest("Name is required");
                }
                if (_service.GetById(langue.name) != null)
                {
                    return BadRequest("Name already exists");
                }
                var newGroup = await _service.Add(langue);
                return Ok(newGroup);
            }
            catch (Exception ex)
            {
                // Journaliser l'exception
                _logger.LogError(ex, "Une erreur s'est produite lors de l'ajout de la langue avec le nom {name}.", langue.name);

                // Retourner une réponse d'erreur
                return StatusCode(400, ex.Message);
            }
        }

        [HttpDelete("{name}")]
        public async Task<ActionResult<LangueDTO>> DeleteLangue(string name)
        {
            try
            {
                _logger.LogInformation("Deleting a langue with name : {name}", name);
                var group = await _service.Delete(name);
                return Ok(group);
            }
            catch (Exception ex)
            {
                // Journaliser l'exception
                _logger.LogError(ex, "Une erreur s'est produite lors de la suppression de la langue avec le nom {name}.", name);

                // Retourner une réponse d'erreur
                return StatusCode(400, ex.Message);
            }
        }

    }
}
