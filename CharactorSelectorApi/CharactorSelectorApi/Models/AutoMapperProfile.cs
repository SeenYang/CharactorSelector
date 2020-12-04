using AutoMapper;
using CharactorSelectorApi.Models.Dtos;
using CharactorSelectorApi.Models.Entities;

namespace CharactorSelectorApi.Models
{
    public class AutoMapperProfile : Profile
    {
        /// <summary>
        ///     Add mapping config under this file.
        /// </summary>
        public AutoMapperProfile()
        {
            CreateMap<Character, CharacterDto>();
            CreateMap<Option, OptionDto>();
        }
    }
}