using DTO;
using DTOToEntity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IService<UserDTO> _service;
        private readonly ILogger<UserController> _logger;

        public UserController(IService<UserDTO> userService, ILogger<UserController> logger)
        {
            _service = userService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
        {
            _logger.LogInformation("Getting Users ");
            var users = await _service.Gets();
            return Ok(users);
        }

        [HttpPost]
        public async Task<ActionResult<UserDTO>> AddUser([FromQuery] UserDTO user)
        {
            _logger.LogInformation("Adding a user with id : {id}", user.Id);
            user.Id = _service.Gets().Result.Count() + 1;
            var newUser = await _service.Add(user);
            return Ok(newUser);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UserDTO>> DeleteUser(int id)
        {
            _logger.LogInformation("Deleting a user with id : {id}", id);
            var user = await _service.Delete(id);
            return Ok(user);
        }

        [HttpPut]
        public async Task<ActionResult<UserDTO>> UpdateUser([FromQuery] UserDTO user)
        {
            _logger.LogInformation("Updating a user with id : {id}", user.Id);
            var updatedUser = await _service.Update(user);
            return Ok(updatedUser);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetUser(int id)
        {
            _logger.LogInformation("Getting a user with id {id}", id);
            var user = await _service.GetById(id);
            return Ok(user);
        }
    }
}
