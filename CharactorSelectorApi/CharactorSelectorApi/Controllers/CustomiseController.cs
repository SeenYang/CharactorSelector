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
    public class CustomiseController : ControllerBase
    {
        private readonly ILogger<CustomiseController> _logger;
        private readonly ICustomiseService _service;

        /// <summary>
        ///     This is the endpoint for adding customise character.
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

            var result = await _service.CreateCustomerCharacter(newCustomise);
            return result != null ? (IActionResult) Ok(result) : BadRequest("Fail to create customise character.");
        }

        [HttpGet("GetCustomiseById/{customiseId}")]
        public async Task<IActionResult> GetCustomiseById(Guid customiseId)
        {
            if (customiseId == Guid.Empty) return BadRequest("Invalid input characterId.");

            var result = await _service.GetCustomiseById(customiseId);
            return result != null ? (IActionResult) Ok(result) : NotFound();
        }

        [HttpGet("GetAllCustomise")]
        public async Task<IActionResult> GetAllCustomise()
        {
            var result = await _service.GetAllCustomises();
            return result != null ? (IActionResult) Ok(result) : NotFound();
        }
    }
}