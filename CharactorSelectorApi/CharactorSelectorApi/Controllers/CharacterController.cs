using System;
using System.Linq;
using System.Threading.Tasks;
using CharactorSelectorApi.Models.Dtos;
using CharactorSelectorApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CharactorSelectorApi.Controllers
{
    [ApiController]
    [Route("api/[controller]s")]
    public class CharacterController : ControllerBase
    {
        private readonly ILogger<CharacterController> _logger;
        private readonly ICharacterServices _services;

        public CharacterController(ICharacterServices services, ILogger<CharacterController> logger)
        {
            _services = services;
            _logger = logger;
        }

        [HttpGet("GetAllCharacters")]
        public async Task<IActionResult> GetAllCharacters()
        {
            var result = await _services.GetAllCharacters();
            return result != null ? (IActionResult) Ok(result) : NoContent();
        }

        [HttpGet("GetCharacterById/{characterId}")]
        public async Task<IActionResult> GetCharacterById(Guid characterId)
        {
            if (characterId == Guid.Empty) return BadRequest("Invalid input characterId.");

            var result = await _services.GetCharacterById(characterId);
            return result != null ? (IActionResult) Ok(result) : NoContent();
        }

        [HttpPost("CreateCharacter")]
        public async Task<IActionResult> CreateCharacter([FromBody] CharacterDto newCharacter)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Select(x => x.Value.Errors)
                    .Where(y => y.Count > 0)
                    .ToList();
                _logger.LogError($"Invalid input. {errors}");
                return BadRequest($"Invalid input. {errors}");
            }

            var result = await _services.CreateCharacter(newCharacter);
            return result != null ? (IActionResult) Ok(result) : BadRequest("Fail to create character.");
        }

        /// <summary>
        /// This is the endpoint for adding customise character.
        /// </summary>
        /// <param name="newCustomise"></param>
        /// <returns></returns>
        [HttpPost("CreateCustomerCharacter")]
        public async Task<IActionResult> CreateCustomerCharacter([FromBody] CustomiseCharacterDto newCustomise)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Select(x => x.Value.Errors)
                    .Where(y => y.Count > 0)
                    .ToList();
                _logger.LogError($"Invalid input. {errors}");
                return BadRequest($"Invalid input. {errors}");
            }

            var result = await _services.CreateCustomerCharacter(newCustomise);
            return result != null ? (IActionResult) Ok(result) : BadRequest("Fail to create customise character.");
        }
        
        [HttpGet("GetCustomiseById/{customiseId}")]
        public async Task<IActionResult> GetCustomiseById(Guid customiseId)
        {
            if (customiseId == Guid.Empty) return BadRequest("Invalid input characterId.");

            var result = await _services.GetCustomiseById(customiseId);
            return result != null ? (IActionResult) Ok(result) : NoContent();
        }

    }
}