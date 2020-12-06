using System;

namespace CharactorSelectorApi.Models.Entities
{
    public class CustomiseCharacter
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public Guid CharacterId { get; set; }
    }

    public class CustomiseOption
    {
        public Guid CustomiseId { get; set; }
        public Guid OptionId { get; set; }
    }
}