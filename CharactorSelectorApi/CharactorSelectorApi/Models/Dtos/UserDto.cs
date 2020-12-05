using System;
using System.ComponentModel.DataAnnotations;

namespace CharactorSelectorApi.Models.Dtos
{
    public class UserDto
    {
        public Guid Id { get; set; }

        [StringLength(255, ErrorMessage = "{0} length can not greater than {1}.")]
        public string Name { get; set; }
    }
}