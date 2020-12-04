using System;

namespace CharactorSelectorApi.Models.Dtos
{
    public class OptionDto
    {
        public Guid Id { get; set; }
        public Guid? ParentOption { get; set; }
        public Guid CharacterId { get; set; }
        public OptionType Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }
    }
}