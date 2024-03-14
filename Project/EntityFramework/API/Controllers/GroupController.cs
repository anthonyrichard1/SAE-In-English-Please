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
    public class GroupController : ControllerBase
    {
        private readonly IGroupService _service;
        private readonly ILogger<GroupController> _logger;

        public GroupController(IGroupService groupService, ILogger<GroupController> logger)
        {
            _service = groupService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<PageResponse<GroupDTO>>> GetGroups(int index, int count)
        {
            try
            {
                _logger.LogInformation("Getting groups ");
                var groups = await _service.Gets(index, count);
                return groups;
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
        public async Task<ActionResult<GroupDTO>> GetGroup(long id)
        {
            try
            {
                _logger.LogInformation("Getting a group with id {id}", id);

                var group = await _service.GetById(id);
                if (group == null)
                {
                    return NotFound();
                }

                return group;
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
        public async Task<ActionResult<GroupDTO>> UpdateGroup([FromBody]GroupDTO group)
        {
            try
            {
                _logger.LogInformation("Updating a group with id : {id}", group.Id);
                var updatedGroup = await _service.Update(group);
                return updatedGroup;
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
                return newGroup;
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
        public async Task<ActionResult<GroupDTO>> DeleteGroup(long id)
        {
            try
            {
                _logger.LogInformation("Deleting a group with id : {id}", id);
                var group = await _service.Delete(id);
                return group;
            }
            catch (Exception ex)
            {
                // Journaliser l'exception
                _logger.LogError(ex, "Une erreur s'est produite lors de la suppression du groupe avec l'ID {id}.", id);

                // Retourner une réponse d'erreur
                return StatusCode(400,ex.Message);
            }
        }

        [HttpGet("/num/{num}")]
        public async Task<ActionResult<PageResponse<GroupDTO>>> GetGroupsByNum(int index, int count, int num)
        {
            try
            {
                _logger.LogInformation("Getting groups by num : {num}", num);
                var groups = await _service.GetByNum(index, count, num);
                return groups;
            }
            catch (Exception ex)
            {
                // Journaliser l'exception
                _logger.LogError(ex, "Une erreur s'est produite lors de la récupération des groupes avec le numéro {num}.", num);

                // Retourner une réponse d'erreur
                return StatusCode(400,ex.Message);
            }
        }

        [HttpGet("/sector/{sector}")]
        public async Task<ActionResult<PageResponse<GroupDTO>>> GetGroupsBySector(int index, int count, string sector)
        {
            try
            {
                _logger.LogInformation("Getting groups by sector : {sector}", sector);
                var groups = await _service.GetBySector(index, count, sector);
                return groups;
            }
            catch (Exception ex)
            {
                // Journaliser l'exception
                _logger.LogError(ex, "Une erreur s'est produite lors de la récupération des groupes avec le secteur {sector}.", sector);

                // Retourner une réponse d'erreur
                return StatusCode(400,ex.Message);
            }
        }

        [HttpGet("/year/{year}")]
        public async Task<ActionResult<PageResponse<GroupDTO>>> GetGroupsByYear(int index, int count, int year)
        {
            try
            {
                _logger.LogInformation("Getting groups by year : {year}", year);
                var groups = await _service.GetByYear(index, count, year);
                return groups;
            }
            catch (Exception ex)
            {
                // Journaliser l'exception
                _logger.LogError(ex, "Une erreur s'est produite lors de la récupération des groupes avec l'année {year}.", year);

                // Retourner une réponse d'erreur
                return StatusCode(400,ex.Message);
            }
        }


    }
}
