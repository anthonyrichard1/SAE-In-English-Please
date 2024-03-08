using DTO;
using DTOToEntity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
        public async Task<ActionResult<IEnumerable<RoleDTO>>> GetRoles()
        {
            _logger.LogInformation("Getting Roles ");
            var groups = await _service.Gets();
            return Ok(groups);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RoleDTO>> GetRole(int id)
        {
            _logger.LogInformation("Getting a role with id {id}",id);
            var group = await _service.GetById(id);
            return Ok(group);
        }

        [HttpPut]
        public async Task<ActionResult<RoleDTO>> UpdateRole([FromQuery] RoleDTO role)
        {
            _logger.LogInformation("Updating a role with id : {id}", role.Id);
            var updatedGroup = await _service.Update(role);
            return Ok(updatedGroup);
        }

        [HttpPost]
        public async Task<ActionResult<RoleDTO>> AddRole([FromQuery] RoleDTO role)
        {
            _logger.LogInformation("Adding a role with id : {id}", role.Id);
            role.Id = _service.Gets().Result.Count() + 1;
            var newGroup = await _service.Add(role);
            return Ok(newGroup);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<RoleDTO>> DeleteRole(int id)
        {
            _logger.LogInformation("Deleting a role with id : {id}", id);
            var group = await _service.Delete(id);
            return Ok(group);
        }
    }
}
