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

        public async Task<List<CharacterDto>> GetAllCharacters()
        {
            return await _repo.GetAllCharacters();
        }

        public async Task<CharacterDto> GetCharacterById(Guid characterId)
        {
            return await _repo.GetCharacterById(characterId, true);
        }

        public async Task<CharacterDto> CreateCharacter(CharacterDto newCharacter)
        {
            var existing = _repo.GetCharacterByName(newCharacter.Name);

            if (existing == null)
                return await _repo.CreateCharacter(newCharacter);
            _logger.LogError("Invalid new character: Name exist.");
            return null;
        }

        public async Task<CharacterDto> UpdateCharacter(CharacterDto character)
        {
            var existing = _repo.GetCharacterById(character.Id, includeOption: false);

            if (existing != null)
                return await _repo.UpdateCharacter(character);

            _logger.LogError($"Fail to update character: Can not find character: {character.Id}.");
            return null;
        }

        public async Task<List<OptionDto>> GetOptionsByCharacterId(Guid characterId)
        {
            return await _repo.GetOptionsByCharacterId(characterId);
        }

        public async Task<OptionDto> CreateOption(OptionDto newOption)
        {
            var character = await _repo.GetCharacterById(newOption.CharacterId, includeOption: false);
            if (character == null)
            {
                _logger.LogError($"Fail to create new Option: Character {newOption.CharacterId} can not be found.");
                return null;
            }

            if (character.Options.Any(o =>
                string.Equals(o.Name, newOption.Name, StringComparison.InvariantCultureIgnoreCase)))
            {
                _logger.LogError($"Fail to create new Option: Option name {newOption.Name} exist.");
                return null;
            }

            return await _repo.CreateOption(newOption);
        }

        public async Task<OptionDto> UpdateOption(OptionDto option)
        {
            var character = await _repo.GetCharacterById(option.CharacterId, includeOption: false);
            if (character == null)
            {
                _logger.LogError($"Fail to create new Option: Character {option.CharacterId} can not be found.");
                return null;
            }

            return await _repo.UpdateOption(option);
        }
    }
}