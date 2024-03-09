using DTO;
using DTOToEntity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VocabularyListController : ControllerBase
    {
        private readonly IService<VocabularyListDTO> _service;
        private readonly ILogger<VocabularyListController> _logger;

        public VocabularyListController(IService<VocabularyListDTO> vocService, ILogger<VocabularyListController> logger)
        {
            _service = vocService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VocabularyListDTO>>> GetVocabularyLists(int index, int count)
        {
            try
            {
                _logger.LogInformation("Getting VocabularyLists ");
                var VocabularyLists = await _service.Gets(index, count);
                return Ok(VocabularyLists);
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
        public async Task<ActionResult<VocabularyListDTO>> GetVocabularyList(int id)
        {
            try
            {
                _logger.LogInformation("Getting a VocabularyList with id {id}", id);
                var VocabularyList = await _service.GetById(id);
                return Ok(VocabularyList);
            }
            catch (Exception ex)
            {
                // Journaliser l'exception
                _logger.LogError(ex, "Une erreur s'est produite lors de la récupération du VocabularyList avec l'ID {id}.", id);

                // Retourner une réponse d'erreur
                return StatusCode(400, ex.Message);
            }
        }


        [HttpPut]
        public async Task<ActionResult<VocabularyListDTO>> UpdateVocabularyList([FromQuery] VocabularyListDTO VocabularyList)
        {
            try
            {
                _logger.LogInformation("Updating a VocabularyList with id : {id}", VocabularyList.Id);
                var updatedVocabularyList = await _service.Update(VocabularyList);
                return Ok(updatedVocabularyList);
            }
            catch (Exception ex)
            {
                // Journaliser l'exception
                _logger.LogError(ex, "Une erreur s'est produite lors de la mise à jour du VocabularyList avec l'ID {id}.", VocabularyList.Id);

                // Retourner une réponse d'erreur
                return StatusCode(400, ex.Message);
            }
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<VocabularyListDTO>> DeleteVocabularyList(int id)
        {
            try
            {
                _logger.LogInformation("Deleting a VocabularyList with id : {id}", id);
                var VocabularyList = await _service.Delete(id);
                return Ok(VocabularyList);
            }
            catch (Exception ex)
            {
                // Journaliser l'exception
                _logger.LogError(ex, "Une erreur s'est produite lors de la suppression du VocabularyList avec l'ID {id}.", id);

                // Retourner une réponse d'erreur
                return StatusCode(400, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<VocabularyListDTO>> AddVocabularyList([FromQuery] VocabularyListDTO VocabularyList)
        {
            try
            {
                _logger.LogInformation("Adding a VocabularyList with id : {id}", VocabularyList.Id);
                VocabularyList.Id = _service.Gets(0, 0).Result.TotalCount + 1;
                var newVocabularyList = await _service.Add(VocabularyList);
                return Ok(newVocabularyList);
            }
            catch (Exception ex)
            {
                // Journaliser l'exception
                _logger.LogError(ex, "Une erreur s'est produite lors de l'ajout du VocabularyList avec l'ID {id}.", VocabularyList.Id);

                // Retourner une réponse d'erreur
                return StatusCode(400, ex.Message);
            }
        }
    }
}
