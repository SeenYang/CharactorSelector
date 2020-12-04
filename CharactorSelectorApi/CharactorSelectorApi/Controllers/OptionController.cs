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
    // TODO: wrap exception and error by middleware.
    public class OptionController : ControllerBase
    {
        private readonly ILogger<OptionController> _logger;
        private readonly ICharacterServices _services;

        public OptionController(ICharacterServices services, ILogger<OptionController> logger)
        {
            _services = services;
            _logger = logger;
        }

        [HttpGet("GetOptionsByCharacterId/{characterId}")]
        public async Task<IActionResult> GetAllCharacters(Guid characterId)
        {
            if (characterId == Guid.Empty) return BadRequest("Invalid input characterId.");
            var result = await _services.GetOptionsByCharacterId(characterId);
            return result != null ? (IActionResult) Ok(result) : NoContent();
        }

        [HttpPost("CreateOption")]
        public async Task<IActionResult> CreateOption([FromBody] OptionDto newOption)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Select(x => x.Value.Errors)
                    .Where(y => y.Count > 0)
                    .ToList();
                _logger.LogError($"Invalid input. {errors}");
                return BadRequest($"Invalid input. {errors}");
            }

            var result = await _services.CreateOption(newOption);
            return result != null ? (IActionResult) Ok(result) : BadRequest("Fail to create option.");
        }

        [HttpPost("UpdateOption")]
        public async Task<IActionResult> UpdateOption([FromBody] OptionDto option)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Select(x => x.Value.Errors)
                    .Where(y => y.Count > 0)
                    .ToList();
                _logger.LogError($"Invalid input. {errors}");
                return BadRequest($"Invalid input. {errors}");
            }

            var result = await _services.UpdateOption(option);
            return result != null ? (IActionResult) Ok(result) : BadRequest("Fail to update option.");
        }
    }
}