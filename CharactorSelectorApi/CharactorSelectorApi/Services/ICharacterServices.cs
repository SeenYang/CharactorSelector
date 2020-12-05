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
        Task<CustomiseCharacterDto> CreateCustomerCharacter(CustomiseCharacterDto newCustomise);
        Task<CustomiseCharacterDto> GetCustomiseById(Guid customiseId);

        // Options
        Task<List<OptionDto>> GetOptionsByCharacterId(Guid characterId);
        Task<OptionDto> UpdateOption(OptionDto option);
    }
}