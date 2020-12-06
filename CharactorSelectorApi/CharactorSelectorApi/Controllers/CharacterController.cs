using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CharactorSelectorApi.Filters;
using CharactorSelectorApi.Models.Dtos;
using CharactorSelectorApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CharactorSelectorApi.Controllers
{
    /// <summary>
    ///     Character Controller
    /// </summary>
    [ApiController]
    [Route("api/[controller]s")]
    public class CharacterController : ControllerBase
    {
        private readonly ILogger<CharacterController> _logger;
        private readonly ICharacterService _service;

        /// <summary>
        ///     Character Controller
        /// </summary>
        /// <param name="service"></param>
        /// <param name="logger"></param>
        public CharacterController(ICharacterService service, ILogger<CharacterController> logger)
        {
            _service = service;
            _logger = logger;
        }

        /// <summary>
        ///     Get All Characters
        /// </summary>
        /// <returns code="200" cerf="List&lt;CharacterDto&gt;">Success response</returns>
        /// <returns code="404">Fail to fetch character or not found.</returns>
        /// <returns code="500">All other error.</returns>
        [HttpGet("GetAllCharacters")]
        [ProducesResponseType(typeof(int), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(List<CharacterDto>), StatusCodes.Status200OK)]
        // [ProducesResponseType(typeof(HttpResponse), 400)]
        public async Task<IActionResult> GetAllCharacters()
        {
            var result = await _service.GetAllCharacters();
            return result != null ? (IActionResult) Ok(result) : NotFound();
        }

        /// <summary>
        ///     Get Character By Id
        /// </summary>
        /// <param name="characterId"></param>
        /// <returns code="200" cref="CharacterDto">Success get modal by Id</returns>
        /// <returns code="404" cref="CharacterDto">Fail to fetch character by provided id</returns>
        [HttpGet("GetCharacterById/{characterId}")]
        [ProducesResponseType(typeof(int), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(CharacterDto), StatusCodes.Status200OK)]
        // [ProducesResponseType(null, 404)]
        public async Task<IActionResult> GetCharacterById(Guid characterId)
        {
            if (characterId == Guid.Empty) return BadRequest("Invalid input characterId.");

            var result = await _service.GetCharacterById(characterId);
            return result != null ? (IActionResult) Ok(result) : NotFound();
        }

        /// <summary>
        ///     Create new Character.
        /// </summary>
        /// <remarks>
        ///     Input character's options need to be structured.
        ///     system will automatically generate ids and retains the relationship.
        /// </remarks>
        /// <param name="newCharacter">No Ids need to provide. Ids will be assigned by system.</param>
        /// <returns code="200">Success created CharacterDto</returns>
        /// <returns code="400">Modal validation fail or creation fail.</returns>
        /// <returns code="500">All other internal error.</returns>
        [HttpPost("CreateCharacter")]
        [ProducesResponseType(typeof(int), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(CharacterDto), StatusCodes.Status200OK)]
        // [ProducesResponseType(null, 400)]
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

            var result = await _service.CreateCharacter(newCharacter);
            return result != null ? (IActionResult) Ok(result) : BadRequest("Fail to create character.");
        }
    }
}