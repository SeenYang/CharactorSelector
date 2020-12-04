using System;
using System.Threading.Tasks;
using CharactorSelectorApi.Models.Dtos;
using CharactorSelectorApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NLog;

namespace CharactorSelectorApi.Controllers
{
    [ApiController]
    [Route("api/[controller]s")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterServices _services;
        private readonly ILogger<CharacterController> _logger;

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
            if (characterId == Guid.Empty)
            {
                return BadRequest("Invalid input characterId.");
            }
            
            var result = await _services.GetCharacterById(characterId);
            return result != null ? (IActionResult) Ok(result) : NoContent();
        }

        [HttpPost("CreateCharacter")]
        public async Task<IActionResult> CreateCharacter([FromBody] CharacterDto newCharacter)
        {
            if (!ModelState.IsValid)
            {
                // TODO: Get validation result message.
                return BadRequest($"Invalid input. {ModelState}");
            }

            var result = await _services.CreateCharacter(newCharacter);
            return result != null ? (IActionResult) Ok(result) : BadRequest("Fail to create character.");
        }
        
        [HttpPost("UpdateCharacter")]
        public async Task<IActionResult> UpdateCharacter([FromBody] CharacterDto character)
        {
            if (!ModelState.IsValid)
            {
                // TODO: Get validation result message.
                return BadRequest($"Invalid input. {ModelState}");
            }

            var result = await _services.UpdateCharacter(character);
            return result != null ? (IActionResult) Ok(result) : BadRequest("Fail to update character.");
        }
    }
}