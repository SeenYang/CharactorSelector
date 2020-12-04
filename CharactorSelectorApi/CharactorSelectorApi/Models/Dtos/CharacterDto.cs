using System;
using System.Collections.Generic;

namespace CharactorSelectorApi.Models.Dtos
{
    public class CharacterDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }
        public CharacterType Type { get; set; }
        public List<OptionDto> Options { get; set; }
    }
}