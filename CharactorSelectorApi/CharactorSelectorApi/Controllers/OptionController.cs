using System;
using System.Threading.Tasks;
using CharactorSelectorApi.Models.Dtos;
using CharactorSelectorApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CharactorSelectorApi.Controllers
{ 
    [ApiController]
    [Route("api/[controller]s")]
    // TODO: wrap exception and error by middleware.
    public class OptionController: ControllerBase
    { 
        private readonly ICharacterServices _services;
        private readonly ILogger<OptionController> _logger;

        public OptionController(ICharacterServices services, ILogger<OptionController> logger)
        {
            _services = services;
            _logger = logger;
        }
        
        [HttpGet("GetOptionsByCharacterId/{characterId}")]
        public async Task<IActionResult> GetAllCharacters(Guid characterId)
        {            
            if (characterId == Guid.Empty)
            {
                return BadRequest("Invalid input characterId.");
            }
            var result = await _services.GetOptionsByCharacterId(characterId);
            return result != null ? (IActionResult) Ok(result) : NoContent();
        }
        
        [HttpPost("CreateOption")]
        public async Task<IActionResult> CreateOption([FromBody] OptionDto newOption)
        {
            if (!ModelState.IsValid)
            {
                // TODO: Get validation result message.
                return BadRequest($"Invalid input. {ModelState}");
            }

            var result = await _services.CreateOption(newOption);
            return result != null ? (IActionResult) Ok(result) : BadRequest("Fail to create option.");
        }
        
        [HttpPost("UpdateOption")]
        public async Task<IActionResult> UpdateOption([FromBody] OptionDto option)
        {
            if (!ModelState.IsValid)
            {
                // TODO: Get validation result message.
                return BadRequest($"Invalid input. {ModelState}");
            }

            var result = await _services.UpdateOption(option);
            return result != null ? (IActionResult) Ok(result) : BadRequest("Fail to update option.");
        }
    }
}