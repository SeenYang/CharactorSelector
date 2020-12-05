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
            CreateMap<CharacterDto, Character>();
            CreateMap<Option, OptionDto>();
            CreateMap<OptionDto, Option>();
            CreateMap<UserDto, User>();
            CreateMap<User, UserDto>();
            CreateMap<CustomiseCharacterDto, CustomiseCharacter>();
            CreateMap<CustomiseCharacter, CustomiseCharacterDto>();
        }
    }
}