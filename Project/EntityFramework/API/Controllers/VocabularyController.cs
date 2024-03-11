
using DTO;
using DTOToEntity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class VocabularyController : ControllerBase
    {
        private readonly IVocabularyService _service;
        private readonly ILogger<VocabularyController> _logger;

        public VocabularyController(IVocabularyService vocService, ILogger<VocabularyController> logger)
        {
            _service = vocService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VocabularyDTO>>> GetVocabularies(int index, int count)
        {
            try
            {
                _logger.LogInformation("Getting vocabularies ");
                var vocabularies = await _service.Gets(index, count);
                return Ok(vocabularies);
            }
            catch (Exception ex)
            {
                // Journaliser l'exception
                _logger.LogError(ex, "Une erreur s'est produite lors de la récupération des vocabulaires.");

                // Retourner une réponse d'erreur
                return StatusCode(400, ex.Message);
            }
        }

        [HttpGet("{word}")]

        public async Task<ActionResult<VocabularyDTO>> GetVocabulary(string word)
        {
            try
            {
                _logger.LogInformation("Getting a vocabulary with id {id}", word);
                var vocabulary = await _service.GetById(word);
                return Ok(vocabulary);
            }
            catch (Exception ex)
            {
                // Journaliser l'exception
                _logger.LogError(ex, "Une erreur s'est produite lors de la récupération du vocabulaire avec l'ID {word}.", word);

                // Retourner une réponse d'erreur
                return StatusCode(400, ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<VocabularyDTO>> UpdateVocabulary([FromQuery] VocabularyDTO vocabulary)
        {
            try
            {
                _logger.LogInformation("Updating a vocabulary with word : {word}", vocabulary.word);
                var updatedVocabulary = await _service.Update(vocabulary);
                return Ok(updatedVocabulary);
            }
            catch (Exception ex)
            {
                // Journaliser l'exception
                _logger.LogError(ex, "Une erreur s'est produite lors de la mise à jour du vocabulaire avec l'ID {word}.", vocabulary.word);

                // Retourner une réponse d'erreur
                return StatusCode(400, ex.Message);
            }
        }

        [HttpDelete("{word}")]
        public async Task<ActionResult<VocabularyDTO>> DeleteVocabulary(string word)
        {
            try
            {
                _logger.LogInformation("Deleting a vocabulary with word : {word}", word);
                var vocabulary = await _service.Delete(word);
                return Ok(vocabulary);
            }
            catch (Exception ex)
            {
                // Journaliser l'exception
                _logger.LogError(ex, "Une erreur s'est produite lors de la suppression du vocabulaire avec l'ID {word}.", word);

                // Retourner une réponse d'erreur
                return StatusCode(400, ex.Message);
            }
        }


        [HttpPost]
        public async Task<ActionResult<VocabularyDTO>> AddVocabulary([FromQuery] VocabularyDTO vocabulary)
        {
            try
            {
                _logger.LogInformation("Adding a vocabulary with word : {word}", vocabulary.word);
                var newVocabulary = await _service.Add(vocabulary);
                return Ok(newVocabulary);
            }
            catch (Exception ex)
            {
                // Journaliser l'exception
                _logger.LogError(ex, "Une erreur s'est produite lors de l'ajout du vocabulaire avec l'ID {word}.", vocabulary.word);

                // Retourner une réponse d'erreur
                return StatusCode(400, ex.Message);
            }
        }

        [HttpGet("langue/{langue}")]
        public async Task<ActionResult<PageResponse<VocabularyDTO>>> GetByLangue(string langue, int index, int count)
        {
            try
            {
                _logger.LogInformation("Getting vocabularies by langue {langue}",langue);
                var vocabularies = await _service.GetByLangue(index, count, langue);
                return Ok(vocabularies);
            }
            catch (Exception ex)
            {
                // Journaliser l'exception
                _logger.LogError(ex, "Une erreur s'est produite lors de la récupération des vocabulaires par langue {langue}.",langue);

                // Retourner une réponse d'erreur
                return StatusCode(400, ex.Message);
            }
        }

    }
}
