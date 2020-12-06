using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CharactorSelectorApi.Models.Dtos;

namespace CharactorSelectorApi.Repository
{
    public interface ICharacterRepository
    {
        // Character
        Task<List<CharacterDto>> GetAllCharacters();
        Task<CharacterDto> GetCharacterById(Guid characterId, bool includeOption = true);
        Task<CharacterDto> GetCharacterByName(string name);
        Task<CharacterDto> CreateCharacter(CharacterDto newCharacter);
        Task<CharacterDto> UpdateCharacter(CharacterDto character);

        // Options
        Task<List<OptionDto>> GetOptionsByCharacterId(Guid characterId);
        Task<bool> CreateOption(List<OptionDto> newOptions);
        Task<OptionDto> UpdateOption(OptionDto option);

        // Customise
        Task<CustomiseCharacterDto> GetCustomiseById(Guid CustomiseId);
        Task<List<CustomiseCharacterDto>> GetAllCustomise();
        Task<CustomiseCharacterDto> CreateCustomise(CustomiseCharacterDto newCustomise);
    }
}