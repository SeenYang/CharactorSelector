using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CharactorSelectorApi.Models.Dtos
{
    /// <summary>
    ///     This is the DTO to save and provide customise character.
    /// </summary>
    public class CustomiseCharacterDto
    {
        [Required] public Guid Id { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 2)]
        public string Name { get; set; }

        [Required] public Guid UserId { get; set; }
        public string UserName { get; set; }

        public List<Guid> SelectedOptions { get; set; }

        [Required] public Guid CharacterId { get; set; }
    }
}