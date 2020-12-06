using System;
using System.Threading.Tasks;
using CharactorSelectorApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CharactorSelectorApi.Controllers
{
    [ApiController]
    [Route("api/[controller]s")]
    public class OptionController : ControllerBase
    {
        private readonly ILogger<OptionController> _logger;
        private readonly ICharacterService _service;

        public OptionController(ICharacterService service, ILogger<OptionController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet("GetOptionsByCharacterId/{characterId}")]
        public async Task<IActionResult> GetOptionsByCharacterId(Guid characterId)
        {
            if (characterId == Guid.Empty) return BadRequest("Invalid input characterId.");
            var result = await _service.GetOptionsByCharacterId(characterId);
            return result != null ? (IActionResult) Ok(result) : NoContent();
        }
    }
}