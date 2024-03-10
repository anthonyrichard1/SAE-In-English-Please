﻿using DTO;
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
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers(int index,int count)
        {
            try
            {
                _logger.LogInformation("Getting Users ");
                var users = await _service.Gets(index, count);
                return Ok(users);
            }
            catch (Exception ex)
            {
                // Journaliser l'exception
                _logger.LogError(ex, "Une erreur s'est produite lors de la récupération des utilisateurs.");

                // Retourner une réponse d'erreur
                return StatusCode(400, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<UserDTO>> AddUser([FromQuery] UserDTO user)
        {
            try
            {
                _logger.LogInformation("Adding a user with id : {id}", user.Id);
                user.Id = _service.Gets(0, 0).Result.TotalCount + 1;
                var newUser = await _service.Add(user);
                return Ok(newUser);
            }
            catch (Exception ex)
            {
                // Journaliser l'exception
                _logger.LogError(ex, "Une erreur s'est produite lors de l'ajout de l'utilisateur avec l'ID {id}.", user.Id);

                // Retourner une réponse d'erreur
                return StatusCode(400, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UserDTO>> DeleteUser(int id)
        {
            try
            {
                _logger.LogInformation("Deleting a user with id : {id}", id);
                var user = await _service.Delete(id);
                return Ok(user);
            }
            catch (Exception ex)
            {
                // Journaliser l'exception
                _logger.LogError(ex, "Une erreur s'est produite lors de la suppression de l'utilisateur avec l'ID {id}.", id);

                // Retourner une réponse d'erreur
                return StatusCode(400, ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<UserDTO>> UpdateUser([FromQuery] UserDTO user)
        {
            try
            {
                _logger.LogInformation("Updating a user with id : {id}", user.Id);
                var updatedUser = await _service.Update(user);
                return Ok(updatedUser);
            }
            catch (Exception ex)
            {
                // Journaliser l'exception
                _logger.LogError(ex, "Une erreur s'est produite lors de la mise à jour de l'utilisateur avec l'ID {id}.", user.Id);

                // Retourner une réponse d'erreur
                return StatusCode(400, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetUser(int id)
        {
            try
            {
                _logger.LogInformation("Getting a user with id {id}", id);
                var user = await _service.GetById(id);
                return Ok(user);
            }
            catch (Exception ex)
            {
                // Journaliser l'exception
                _logger.LogError(ex, "Une erreur s'est produite lors de la récupération de l'utilisateur avec l'ID {id}.", id);

                // Retourner une réponse d'erreur
                return StatusCode(400, ex.Message);
            }
        }
    }
}