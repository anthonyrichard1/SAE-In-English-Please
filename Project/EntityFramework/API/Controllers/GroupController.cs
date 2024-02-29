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

        public GroupController(IService<GroupEntity> groupService)
        {
            _groupService = groupService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GroupEntity>>> GetGroups()
        {
            var groups = await _groupService.GetGroups();
            return Ok(groups);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GroupEntity>> GetGroup(int id)
        {
            var group = await _groupService.GetGroup(id);
            return Ok(group);
        }

        [HttpPut]
        public async Task<ActionResult<GroupEntity>> UpdateGroup([FromQuery]GroupEntity group)
        {
            var updatedGroup = await _groupService.UpdateGroup(group);
            return Ok(updatedGroup);
        }

        [HttpPost]
        public async Task<ActionResult<GroupEntity>> AddGroup([FromQuery]GroupEntity group)
        {
            group.Id = _groupService.GetGroups().Result.Count() + 1;
            var newGroup = await _groupService.AddGroup(group);
            return Ok(newGroup);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<GroupEntity>> DeleteGroup(int id)
        {
            var group = await _groupService.DeleteGroup(id);
            return Ok(group);
        }

    }
}
