using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CharactorSelectorApi.Models.Dtos;

namespace CharactorSelectorApi.Services
{
    public interface ICustomiseService
    {
        Task<CustomiseCharacterDto> CreateCustomerCharacter(CustomiseCharacterDto newCustomise);
        Task<CustomiseCharacterDto> GetCustomiseById(Guid customiseId);
        Task<List<CustomiseCharacterDto>> GetAllCustomises();
    }
}