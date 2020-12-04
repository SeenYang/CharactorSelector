using System;

namespace CharactorSelectorApi.Models.Entities
{
    public class Option
    {
        public Guid Id { get; set; }
        public Guid? ParentOptionId { get; set; }
        public Guid CharacterId { get; set; }
        public int Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }
        public virtual Character Character { get; set; }
    }
}