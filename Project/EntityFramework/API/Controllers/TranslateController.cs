﻿using DTO;
using DTOToEntity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TranslateController : ControllerBase
    {
        private readonly IService<TranslateDTO> _service;
        private readonly ILogger<TranslateController> _logger;

        public TranslateController(IService<TranslateDTO> TranslateService, ILogger<TranslateController> logger)
        {
            _service = TranslateService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TranslateDTO>>> GetTranslates(int index, int count)
        {
            try
            {
                _logger.LogInformation("Getting Translates ");
                var Translates = await _service.Gets(index, count);
                return Ok(Translates);
            }
            catch (Exception ex)
            {
                // Journaliser l'exception
                _logger.LogError(ex, "Une erreur s'est produite lors de la récupération des Translates.");

                // Retourner une réponse d'erreur
                return StatusCode(400, ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<TranslateDTO>> GetTranslate(int id)
        {
            try {
            _logger.LogInformation("Getting a Translate with id {id}", id);
            var Translate = await _service.GetById(id);
            return Ok(Translate);
            }
            catch (Exception ex)
            {
                // Journaliser l'exception
                _logger.LogError(ex, "Une erreur s'est produite lors de la récupération du Translate avec l'ID {id}.", id);

                // Retourner une réponse d'erreur
                return StatusCode(400, ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<TranslateDTO>> UpdateTranslate([FromQuery] TranslateDTO Translate)
        {
            try { 
            _logger.LogInformation("Updating a Translate with id : {id}", Translate.Id);
            var updatedTranslate = await _service.Update(Translate);
            return Ok(updatedTranslate);
            }
            catch (Exception ex)
            {
                // Journaliser l'exception
                _logger.LogError(ex, "Une erreur s'est produite lors de la mise à jour du Translate avec l'ID {id}.", Translate.Id);

                // Retourner une réponse d'erreur
                return StatusCode(400, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TranslateDTO>> DeleteTranslate(int id)
        {
            try { 
            _logger.LogInformation("Deleting a Translate with id : {id}", id);
            var Translate = await _service.Delete(id);
            return Ok(Translate);
            }
            catch (Exception ex)
            {
                // Journaliser l'exception
                _logger.LogError(ex, "Une erreur s'est produite lors de la suppression du Translate avec l'ID {id}.", id);

                // Retourner une réponse d'erreur
                return StatusCode(400, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<TranslateDTO>> AddTranslate([FromQuery] TranslateDTO Translate)
        {
            try { 
            _logger.LogInformation("Adding a Translate with id : {id}", Translate.Id);
            Translate.Id = _service.Gets(0,0).Result.TotalCount + 1;
            var newTranslate = await _service.Add(Translate);
            return Ok(newTranslate);
            }
            catch (Exception ex)
            {
                // Journaliser l'exception
                _logger.LogError(ex, "Une erreur s'est produite lors de l'ajout du Translate avec l'ID {id}.", Translate.Id);

                // Retourner une réponse d'erreur
                return StatusCode(400, ex.Message);
            }
        }

    }
}
