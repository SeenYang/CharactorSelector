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
        public async Task<IActionResult> GetOptionsByCharacterId(Guid characterId)
        {
            if (characterId == Guid.Empty) return BadRequest("Invalid input characterId.");
            var result = await _services.GetOptionsByCharacterId(characterId);
            return result != null ? (IActionResult) Ok(result) : NoContent();
        }
    }
}