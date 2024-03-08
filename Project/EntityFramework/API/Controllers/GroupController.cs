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
        public async Task<ActionResult<IEnumerable<GroupDTO>>> GetGroups()
        {
            _logger.LogInformation("Getting groups ");
            var groups = await _service.Gets();
            return Ok(groups);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GroupDTO>> GetGroup(int id)
        {
            _logger.LogInformation("Getting a group with id {id}",id);
            var group = await _service.GetById(id);
            return Ok(group);
        }

        [HttpPut]
        public async Task<ActionResult<GroupDTO>> UpdateGroup([FromQuery]GroupDTO group)
        {
            _logger.LogInformation("Updating a group with id : {id}",group.Id);
            var updatedGroup = await _service.Update(group);
            return Ok(updatedGroup);
        }

        [HttpPost]
        public async Task<ActionResult<GroupDTO>> AddGroup([FromQuery]GroupDTO group)
        {
            _logger.LogInformation("Adding a group with id : {id}",group.Id);
            group.Id = _service.Gets().Result.Count() + 1;
            var newGroup = await _service.Add(group);
            return Ok(newGroup);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<GroupEntity>> DeleteGroup(int id)
        {
            _logger.LogInformation("Deleting a group with id : {id}",id);
            var group = await _service.Delete(id);
            return Ok(group);
        }

    }
}
