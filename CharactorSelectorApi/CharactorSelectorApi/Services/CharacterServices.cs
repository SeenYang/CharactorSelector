using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CharactorSelectorApi.Models.Dtos;
using CharactorSelectorApi.Repository;
using Microsoft.Extensions.Logging;

namespace CharactorSelectorApi.Services
{
    public class CharacterServices : ICharacterServices
    {
        private readonly ILogger<CharacterServices> _logger;
        private readonly ICharacterRepository _repo;

        public CharacterServices(ILogger<CharacterServices> logger, ICharacterRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        /// <summary>
        /// Get All Characters
        /// </summary>
        /// <returns></returns>
        public async Task<List<CharacterDto>> GetAllCharacters()
        {
            return await _repo.GetAllCharacters();
        }
        
        /// <summary>
        /// Get Character By Id
        /// </summary>
        /// <param name="characterId"></param>
        /// <returns></returns>
        public async Task<CharacterDto> GetCharacterById(Guid characterId)
        {
            return await _repo.GetCharacterById(characterId);
        }

        /// <summary>
        /// input character should be structured options.
        /// The hierarchy will be flatten and saved.
        /// </summary>
        /// <param name="newCharacter">CharacterDto with structure options.</param>
        /// <returns></returns>
        public async Task<CharacterDto> CreateCharacter(CharacterDto newCharacter)
        {
            var existing = await _repo.GetCharacterByName(newCharacter.Name);
            if (existing == null)
            {
                var created = await _repo.CreateCharacter(newCharacter);
                if (newCharacter.Options != null && newCharacter.Options.Any())
                {
                    var flatted = InitiateNewOptionList(newCharacter.Options, created.Id);
                    var result = await _repo.CreateOptions(flatted);
                    if (!result)
                    {
                        _logger.LogError($"Fail to create options for character {created.Id}.");
                        return null;
                    }
                }

                var returnResult = await _repo.GetCharacterById(created.Id, true);
                return returnResult;
            }

            _logger.LogError("Invalid new character: Name exist.");
            return null;
        }

        /// <summary>
        /// Create Customer Character
        /// </summary>
        /// <param name="newCustomise"></param>
        /// <returns></returns>
        public async Task<CustomiseCharacterDto> CreateCustomerCharacter(CustomiseCharacterDto newCustomise)
        {
            var created = await _repo.CreateCustomise(newCustomise);
            return created;
        }

        /// <summary>
        /// Get Customise By Id
        /// </summary>
        /// <param name="customiseId"></param>
        /// <returns></returns>
        public async Task<CustomiseCharacterDto> GetCustomiseById(Guid customiseId)
        {
            return await _repo.GetCustomiseById(customiseId);
        }

        /// <summary>
        /// Get All Customises
        /// </summary>
        /// <returns></returns>
        public async Task<List<CustomiseCharacterDto>> GetAllCustomises()
        {
            return await _repo.GetAllCustomise();
        }

        /// <summary>
        /// Taking structured option list, initiate the ids.
        /// </summary>
        /// <param name="options">Structured Option list</param>
        /// <param name="characterId"></param>
        /// <returns></returns>
        private List<OptionDto> InitiateNewOptionList(List<OptionDto> options, Guid characterId)
        {
            var returnList = new List<OptionDto>();
            foreach (var option in options)
            {
                var optionId = Guid.NewGuid();
                option.Id = optionId;
                option.CharacterId = characterId;
                returnList.Add(option);
                if (option.SubOptions.Any())
                {
                    returnList.AddRange(InitiateSubOptions(option.SubOptions, optionId, characterId));
                }
            }

            return returnList;
        }

        private List<OptionDto> InitiateSubOptions(List<OptionDto> subOptions, Guid parentId, Guid characterId)
        {
            var returnList = new List<OptionDto>();
            foreach (var option in subOptions)
            {
                var optionId = Guid.NewGuid();
                option.Id = optionId;
                option.ParentOptionId = parentId;
                option.CharacterId = characterId;
                if (option.SubOptions.Any())
                {
                    returnList.AddRange(InitiateSubOptions(option.SubOptions, optionId, characterId));
                }
            }

            returnList.AddRange(subOptions);
            return returnList;
        }

        /// <summary>
        /// Get Options By CharacterId
        /// </summary>
        /// <param name="characterId"></param>
        /// <returns></returns>
        public async Task<List<OptionDto>> GetOptionsByCharacterId(Guid characterId)
        {
            return await _repo.GetOptionsByCharacterId(characterId);
        }

        /// <summary>
        /// Update Option
        /// </summary>
        /// <param name="option"></param>
        /// <returns></returns>
        public async Task<OptionDto> UpdateOption(OptionDto option)
        {
            var character = await _repo.GetCharacterById(option.CharacterId, false);
            if (character == null)
            {
                _logger.LogError($"Fail to create new Option: Character {option.CharacterId} can not be found.");
                return null;
            }

            return await _repo.UpdateOption(option);
        }
    }
}