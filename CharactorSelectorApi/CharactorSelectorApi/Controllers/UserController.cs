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
    
    public class UserController:ControllerBase
    {
        private readonly IUserServices _services;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserServices services, ILogger<UserController> logger)
        {
            _services = services;
            _logger = logger;
        }
        
        [HttpGet("GetUserById/{userId}")]
        public async Task<IActionResult> GetUserById(Guid userId)
        {            
            if (userId == Guid.Empty)
            {
                _logger.LogError($"Invalid Input userId: {userId}");
                return BadRequest("Invalid input characterId.");
            }
            var result = await _services.GetUserById(userId);
            return result != null ? (IActionResult) Ok(result) : NoContent();
        }
        
        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] UserDto newUser)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Select(x => x.Value.Errors)
                    .Where(y=>y.Count>0)
                    .ToList();
                _logger.LogError($"Invalid input. {errors}");
                return BadRequest($"Invalid input. {errors}");
            }

            newUser.Id = Guid.Empty;
            var result = await _services.CreateUser(newUser);
            return result != null ? (IActionResult) Ok(result) : BadRequest("Fail to create user.");
        }
    }
}