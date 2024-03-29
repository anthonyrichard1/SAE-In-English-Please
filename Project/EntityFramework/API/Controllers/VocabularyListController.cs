﻿
using DTO;
using DTOToEntity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class VocabularyListController : ControllerBase
    {
        private readonly IVocabularyListService _service;
        private readonly ILogger<VocabularyListController> _logger;

        public VocabularyListController(IVocabularyListService vocService, ILogger<VocabularyListController> logger)
        {
            _service = vocService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<PageResponse<VocabularyListDTO>>> GetVocabularyLists(int index, int count)
        {
            try
            {
                _logger.LogInformation("Getting VocabularyLists ");
                var VocabularyLists = await _service.Gets(index, count);
                return VocabularyLists;
            }
            catch (Exception ex)
            {
                // Journaliser l'exception
                _logger.LogError(ex, "Une erreur s'est produite lors de la récupération des VocabularyLists.");

                // Retourner une réponse d'erreur
                return StatusCode(400, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VocabularyListDTO>> GetVocabularyList(long id)
        {
            try
            {
                _logger.LogInformation("Getting a GroupVocabularyList with id {id}", id);
                var VocabularyList = await _service.GetById(id);
                return VocabularyList;
            }
            catch (Exception ex)
            {
                // Journaliser l'exception
                _logger.LogError(ex, "Une erreur s'est produite lors de la récupération du GroupVocabularyList avec l'ID {id}.", id);

                // Retourner une réponse d'erreur
                return StatusCode(400, ex.Message);
            }
        }


        [HttpPut]
        public async Task<ActionResult<VocabularyListDTO>> UpdateVocabularyList([FromQuery] VocabularyListDTO VocabularyList)
        {
            try
            {
                _logger.LogInformation("Updating a GroupVocabularyList with id : {id}", VocabularyList.Id);
                var updatedVocabularyList = await _service.Update(VocabularyList);
                return updatedVocabularyList;
            }
            catch (Exception ex)
            {
                // Journaliser l'exception
                _logger.LogError(ex, "Une erreur s'est produite lors de la mise à jour du GroupVocabularyList avec l'ID {id}.", VocabularyList.Id);

                // Retourner une réponse d'erreur
                return StatusCode(400, ex.Message);
            }
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<VocabularyListDTO>> DeleteVocabularyList(long id)
        {
            try
            {
                _logger.LogInformation("Deleting a GroupVocabularyList with id : {id}", id);
                var VocabularyList = await _service.Delete(id);
                return VocabularyList;
            }
            catch (Exception ex)
            {
                // Journaliser l'exception
                _logger.LogError(ex, "Une erreur s'est produite lors de la suppression du GroupVocabularyList avec l'ID {id}.", id);

                // Retourner une réponse d'erreur
                return StatusCode(400, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<VocabularyListDTO>> AddVocabularyList([FromQuery] VocabularyListDTO VocabularyList)
        {
            try
            {
                _logger.LogInformation("Adding a GroupVocabularyList with id : {id}", VocabularyList.Id);
                VocabularyList.Id = _service.Gets(0, 0).Result.TotalCount + 1;
                var newVocabularyList = await _service.Add(VocabularyList);
                return newVocabularyList;
            }
            catch (Exception ex)
            {
                // Journaliser l'exception
                _logger.LogError(ex, "Une erreur s'est produite lors de l'ajout du GroupVocabularyList avec l'ID {id}.", VocabularyList.Id);

                // Retourner une réponse d'erreur
                return StatusCode(400, ex.Message);
            }
        }

        [HttpGet("user/{user}")]
        public async Task<ActionResult<PageResponse<VocabularyListDTO>>> GetVocabularyListsByUser(int index, int count, int user)
        {
            try
            {
                _logger.LogInformation("Getting VocabularyLists by user {user}", user);
                var VocabularyLists = await _service.GetByUser(index, count, user);
                return VocabularyLists;
            }
            catch (Exception ex)
            {
                // Journaliser l'exception
                _logger.LogError(ex, "Une erreur s'est produite lors de la récupération des VocabularyLists.");

                // Retourner une réponse d'erreur
                return StatusCode(400, ex.Message);
            }
        }

        [HttpPost("AddGroup")]
        public async Task<ActionResult<GroupDTO>> AddGroupToVocabularyList([FromQuery]long groupId, long vocabId)
        {
            try
            {
                _logger.LogInformation("Adding a group to a VocabularyList with id : {id}", vocabId);
                var group = await _service.AddGroupToVocabularyList(groupId, vocabId);
                return group;
            }
            catch (Exception ex)
            {
                // Journaliser l'exception
                _logger.LogError(ex, "Une erreur s'est produite lors de l'ajout du groupe à la VocabularyList avec l'ID {id}.", vocabId);

                // Retourner une réponse d'erreur
                return StatusCode(400, ex.Message);
            }
        }
    }
}
