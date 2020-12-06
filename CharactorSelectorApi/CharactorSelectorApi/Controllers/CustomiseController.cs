using System;
using System.Linq;
using System.Threading.Tasks;
using CharactorSelectorApi.Models.Dtos;
using CharactorSelectorApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CharactorSelectorApi.Controllers
{
    /// <summary>
    /// CustomiseController
    /// </summary>
    [ApiController]
    [Route("api/[controller]s")]
    public class CustomiseController : ControllerBase
    {
        private readonly ILogger<CustomiseController> _logger;
        private readonly ICustomiseService _service;

        /// <summary>
        /// CustomiseController
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="service"></param>
        public CustomiseController(ILogger<CustomiseController> logger, ICustomiseService service)
        {
            _logger = logger;
            _service = service;
        }

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

        /// <summary>
        /// Get Customise By Id
        /// </summary>
        /// <param name="customiseId"></param>
        /// <returns></returns>
        [HttpGet("GetCustomiseById/{customiseId}")]
        public async Task<IActionResult> GetCustomiseById(Guid customiseId)
        {
            if (customiseId == Guid.Empty) return BadRequest("Invalid input characterId.");

            var result = await _service.GetCustomiseById(customiseId);
            return result != null ? (IActionResult) Ok(result) : NotFound();
        }

        /// <summary>
        /// This is endpoint for getting All customise character.
        /// </summary>
        /// <remarks>
        /// ***Please aware the return payload won't contain the selected options.***
        /// 
        /// If need selected options, please take the id to use GetCustomiseById.
        /// </remarks>
        /// <returns code="200" cerf="CustomiseCharacterDto">Success response</returns>
        /// <returns code="404">Fail to fetch character or not found.</returns>
        /// <returns code="500">All other error.</returns>
        [HttpGet("GetAllCustomise")]
        [ProducesResponseType(typeof(int), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(CustomiseCharacterDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllCustomise()
        {
            var result = await _service.GetAllCustomises();
            return result != null ? (IActionResult) Ok(result) : NotFound();
        }
    }
}