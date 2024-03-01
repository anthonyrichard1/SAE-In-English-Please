using Entities;
using Microsoft.AspNetCore.Mvc;
using StubbedContextLib;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GroupController : ControllerBase
    {
        private readonly IService<GroupEntity> _groupService;
        private readonly ILogger<GroupController> _logger;

        public GroupController(IService<GroupEntity> groupService, ILogger<GroupController> logger)
        {
            _groupService = groupService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GroupEntity>>> GetGroups()
        {
            _logger.LogInformation("Getting groups ");
            var groups = await _groupService.GetGroups();
            return Ok(groups);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GroupEntity>> GetGroup(int id)
        {
            _logger.LogInformation("Getting a group with id {id}",id);
            var group = await _groupService.GetGroup(id);
            return Ok(group);
        }

        [HttpPut]
        public async Task<ActionResult<GroupEntity>> UpdateGroup([FromQuery]GroupEntity group)
        {
            _logger.LogInformation("Updating a group with id : {id}",group.Id);
            var updatedGroup = await _groupService.UpdateGroup(group);
            return Ok(updatedGroup);
        }

        [HttpPost]
        public async Task<ActionResult<GroupEntity>> AddGroup([FromQuery]GroupEntity group)
        {
            _logger.LogInformation("Adding a group with id : {id}",group.Id);
            group.Id = _groupService.GetGroups().Result.Count() + 1;
            var newGroup = await _groupService.AddGroup(group);
            return Ok(newGroup);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<GroupEntity>> DeleteGroup(int id)
        {
            _logger.LogInformation("Deleting a group with id : {id}",id);
            var group = await _groupService.DeleteGroup(id);
            return Ok(group);
        }

    }
}
