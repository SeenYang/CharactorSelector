using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CharactorSelectorApi.Models.Dtos
{
    public class OptionDto
    {
        [Required] public Guid Id { get; set; }

        public Guid? ParentOptionId { get; set; }

        [Required] public Guid CharacterId { get; set; }

        public OptionType Type { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 2)]

        public string Name { get; set; }

        [StringLength(100, ErrorMessage = "{0} length can not loger than {1}.")]
        public string Description { get; set; }

        [Url] public string ImgUrl { get; set; }
        public List<OptionDto> SubOptions { get; set; }
    }
}