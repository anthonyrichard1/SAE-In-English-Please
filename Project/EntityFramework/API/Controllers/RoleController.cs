
using DTO;
using DTOToEntity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class RoleController : ControllerBase
    {
        private readonly IService<RoleDTO> _service;
        private readonly ILogger<RoleController> _logger;

        public RoleController(IService<RoleDTO> RoleService, ILogger<RoleController> logger)
        {
            _service = RoleService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoleDTO>>> GetRoles(int index, int count)
        {
            try
            {
                _logger.LogInformation("Getting Roles ");
                var groups = await _service.Gets(index, count);
                return Ok(groups);
            }
            catch (Exception ex)
            {
                // Journaliser l'exception
                _logger.LogError(ex, "Une erreur s'est produite lors de la récupération des roles.");

                // Retourner une réponse d'erreur
                return StatusCode(400, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RoleDTO>> GetRole(int id)
        {
            try
            {
                _logger.LogInformation("Getting a role with id {id}", id);
                var group = await _service.GetById(id);
                return Ok(group);
            }
            catch (Exception ex)
            {
                // Journaliser l'exception
                _logger.LogError(ex, "Une erreur s'est produite lors de la récupération du role avec l'ID {id}.", id);

                // Retourner une réponse d'erreur
                return StatusCode(400, ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<RoleDTO>> UpdateRole([FromQuery] RoleDTO role)
        {
            try { 
            _logger.LogInformation("Updating a role with id : {id}", role.Id);
            var updatedGroup = await _service.Update(role);
            return Ok(updatedGroup);
            }
            catch (Exception ex)
            {
                // Journaliser l'exception
                _logger.LogError(ex, "Une erreur s'est produite lors de la mise à jour du role avec l'ID {id}.", role.Id);

                // Retourner une réponse d'erreur
                return StatusCode(400, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<RoleDTO>> AddRole([FromQuery] RoleDTO role)
        {
            try
            {
                _logger.LogInformation("Adding a role with id : {id}", role.Id);
                role.Id = _service.Gets(0, 0).Result.TotalCount + 1;
                var newGroup = await _service.Add(role);
                return Ok(newGroup);
            }
            catch (Exception ex)
            {
                // Journaliser l'exception
                _logger.LogError(ex, "Une erreur s'est produite lors de l'ajout du role avec l'ID {id}.", role.Id);

                // Retourner une réponse d'erreur
                return StatusCode(400, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<RoleDTO>> DeleteRole(int id)
        {
            try { 
            _logger.LogInformation("Deleting a role with id : {id}", id);
            var group = await _service.Delete(id);
            return Ok(group);
            }
            catch (Exception ex)
            {
                // Journaliser l'exception
                _logger.LogError(ex, "Une erreur s'est produite lors de la suppression du role avec l'ID {id}.", id);

                // Retourner une réponse d'erreur
                return StatusCode(400, ex.Message);
            }
        }
    }
}
