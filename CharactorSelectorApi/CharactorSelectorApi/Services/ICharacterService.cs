using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CharactorSelectorApi.Models.Dtos;

namespace CharactorSelectorApi.Services
{
    public interface ICharacterService
    {
        // Character
        Task<List<CharacterDto>> GetAllCharacters();
        Task<CharacterDto> GetCharacterById(Guid characterId);
        Task<CharacterDto> CreateCharacter(CharacterDto newCharacter);

        // Options
        Task<List<OptionDto>> GetOptionsByCharacterId(Guid characterId);
        Task<OptionDto> UpdateOption(OptionDto option);
    }
}