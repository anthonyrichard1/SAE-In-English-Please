using DTO;
using DTOToEntity;
using Entities;
using Microsoft.AspNetCore.Mvc;
using StubbedContextLib;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GroupController : ControllerBase
    {
        private readonly IService<GroupDTO> _service;
        private readonly ILogger<GroupController> _logger;

        public GroupController(IService<GroupDTO> groupService, ILogger<GroupController> logger)
        {
            _service = groupService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GroupDTO>>> GetGroups(int index, int count)
        {
            try
            {
                _logger.LogInformation("Getting groups ");
                var groups = await _service.Gets(index, count);
                return Ok(groups);
            }
            catch (Exception ex)
            {
                // Journaliser l'exception
                _logger.LogError(ex, "Une erreur s'est produite lors de la récupération des groupes.");

                // Retourner une réponse d'erreur
                return StatusCode(400, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GroupDTO>> GetGroup(int id)
        {
            try
            {
                _logger.LogInformation("Getting a group with id {id}", id);

                var group = await _service.GetById(id);
                if (group == null)
                {
                    return NotFound();
                }

                return Ok(group);
            }
            catch (Exception ex)
            {
                // Journaliser l'exception
                _logger.LogError(ex, "Une erreur s'est produite lors de la récupération du groupe avec l'ID {id}.", id);

                // Retourner une réponse d'erreur
                return StatusCode(400, ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<GroupDTO>> UpdateGroup([FromQuery]GroupDTO group)
        {
            try
            {
                _logger.LogInformation("Updating a group with id : {id}", group.Id);
                var updatedGroup = await _service.Update(group);
                return Ok(updatedGroup);
            }
            catch (Exception ex)
            {
                // Journaliser l'exception
                _logger.LogError(ex, "Une erreur s'est produite lors de la mise à jour du groupe avec l'ID {id}.", group.Id);

                // Retourner une réponse d'erreur
                return StatusCode(400,ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<GroupDTO>> AddGroup([FromQuery]GroupDTO group)
        {
            try
            {
                _logger.LogInformation("Adding a group with id : {id}", group.Id);
                group.Id = _service.Gets(0, 0).Result.TotalCount + 1;
                var newGroup = await _service.Add(group);
                return Ok(newGroup);
            }
            catch (Exception ex)
            {
                // Journaliser l'exception
                _logger.LogError(ex, "Une erreur s'est produite lors de l'ajout du groupe avec l'ID {id}.", group.Id);

                // Retourner une réponse d'erreur
                return StatusCode(400,ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<GroupEntity>> DeleteGroup(int id)
        {
            try
            {
                _logger.LogInformation("Deleting a group with id : {id}", id);
                var group = await _service.Delete(id);
                return Ok(group);
            }
            catch (Exception ex)
            {
                // Journaliser l'exception
                _logger.LogError(ex, "Une erreur s'est produite lors de la suppression du groupe avec l'ID {id}.", id);

                // Retourner une réponse d'erreur
                return StatusCode(400,ex.Message);
            }
        }

    }
}
