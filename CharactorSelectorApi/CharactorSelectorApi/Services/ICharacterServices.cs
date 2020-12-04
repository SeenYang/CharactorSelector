using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CharactorSelectorApi.Models.Dtos;

namespace CharactorSelectorApi.Services
{
    public interface ICharacterServices
    {
        // Character
        Task<List<CharacterDto>> GetAllCharacters();
        Task<CharacterDto> GetCharacterById(Guid characterId);
        Task<CharacterDto> CreateCharacter(CharacterDto newCharacter);
        Task<CharacterDto> UpdateCharacter(CharacterDto character);

        // Options
        Task<List<OptionDto>> GetOptionsByCharacterId(Guid characterId);
        Task<OptionDto> CreateOption(OptionDto newOption);
        Task<OptionDto> UpdateOption(OptionDto option);
    }
}