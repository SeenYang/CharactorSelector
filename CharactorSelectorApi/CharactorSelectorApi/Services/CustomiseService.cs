using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CharactorSelectorApi.Models.Dtos;
using CharactorSelectorApi.Repository;
using Microsoft.Extensions.Logging;

namespace CharactorSelectorApi.Services
{
    public class CustomiseService : ICustomiseService
    {
        private readonly ILogger<CustomiseService> _logger;
        private readonly ICharacterRepository _repo;

        public CustomiseService(ILogger<CustomiseService> logger, ICharacterRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }


        /// <summary>
        ///     Create Customer Character
        /// </summary>
        /// <param name="newCustomise"></param>
        /// <returns></returns>
        public async Task<CustomiseCharacterDto> CreateCustomerCharacter(CustomiseCharacterDto newCustomise)
        {
            var created = await _repo.CreateCustomise(newCustomise);
            return created;
        }

        /// <summary>
        ///     Get Customise By Id
        /// </summary>
        /// <param name="customiseId"></param>
        /// <returns></returns>
        public async Task<CustomiseCharacterDto> GetCustomiseById(Guid customiseId)
        {
            return await _repo.GetCustomiseById(customiseId);
        }

        /// <summary>
        ///     Get All Customises
        /// </summary>
        /// <returns></returns>
        public async Task<List<CustomiseCharacterDto>> GetAllCustomises()
        {
            return await _repo.GetAllCustomise();
        }
    }
}