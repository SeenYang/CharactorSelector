using System;
using System.Collections.Generic;

namespace CharactorSelectorApi.Models.Entities
{
    public class Character
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }
        public int Type { get; set; }
    }
}