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
        Task<CharacterDto> GetCharacterById(Guid characterId);
        Task<CharacterDto> GetCharacterByName(string name);
        Task<CharacterDto> CreateCharacter(CharacterDto newCharacter);
        Task<CharacterDto> UpdateCharacter(CharacterDto character);

        // Options
        Task<List<OptionDto>> GetOptionsByCharacterId(Guid characterId);
        Task<OptionDto> CreateOption(OptionDto newOption);
        Task<OptionDto> UpdateOption(OptionDto option);
    }
}