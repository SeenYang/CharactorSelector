using System;
using System.Linq;
using CharactorSelectorApi.Models.Dtos;
using CharactorSelectorApi.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CharactorSelectorApi.Models
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new ChracterSelectorContext(
                serviceProvider.GetRequiredService<DbContextOptions<ChracterSelectorContext>>());

            if (context.Characters.Any() && context.Options.Any()) return;

            var characterId1 = Guid.NewGuid();
            var characterId2 = Guid.NewGuid();
            var characterId3 = Guid.NewGuid();
            var characterId4 = Guid.NewGuid();
            var characterId5 = Guid.NewGuid();

            var optionId1 = Guid.NewGuid();
            var optionId2 = Guid.NewGuid();
            var optionId3 = Guid.NewGuid();
            var optionId4 = Guid.NewGuid();
            var optionId5 = Guid.NewGuid();
            var optionId6 = Guid.NewGuid();
            var optionId7 = Guid.NewGuid();
            var optionId8 = Guid.NewGuid();
            var optionId9 = Guid.NewGuid();
            var optionId10 = Guid.NewGuid();
            var optionId11 = Guid.NewGuid();
            var optionId12 = Guid.NewGuid();

            var panda = new Character
            {
                Id = characterId1,
                Name = "Panda",
                Description = "This is an Panda. Could customise the food for it.",
                Type = (int) CharacterType.General
            };

            var PandaOption1 = new Option
            {
                Id = optionId1,
                Character = panda,
                CharacterId = panda.Id,
                Description = "Food for Panda",
                Name = "Food",
                ParentOptionId = null,
                Type = (int) OptionType.General
            };

            var PandaSubOption1 = new Option
            {
                Id = optionId2,
                Character = panda,
                CharacterId = panda.Id,
                Description = "Food for Panda",
                Name = "Bamboo",
                ParentOptionId = PandaOption1.Id,
                Type = (int) OptionType.General
            };

            var PandaSubOption2 = new Option
            {
                Id = optionId3,
                Character = panda,
                CharacterId = panda.Id,
                Description = "Food for Panda",
                Name = "Meat",
                ParentOptionId = PandaOption1.Id,
                Type = (int) OptionType.General
            };

            var developer = new Character
            {
                Id = characterId2,
                Name = "Developer",
                Description = "This is lovely developer.",
                Type = (int) CharacterType.General
            };

            var DevOption1 = new Option
            {
                Id = optionId4,
                Character = developer,
                CharacterId = developer.Id,
                Description = "Lang for developer",
                Name = "Language",
                ParentOptionId = null,
                Type = (int) OptionType.General
            };

            var DevSubOption1 = new Option
            {
                Id = optionId5,
                Character = developer,
                CharacterId = developer.Id,
                Description = "Language Option",
                Name = "C#",
                ParentOptionId = DevOption1.Id,
                Type = (int) OptionType.General
            };

            var DevOption2 = new Option
            {
                Id = optionId6,
                Character = developer,
                CharacterId = developer.Id,
                Description = "Speed for developer",
                Name = "Speed",
                ParentOptionId = null,
                Type = (int) OptionType.General
            };

            var DevSubOption2 = new Option
            {
                Id = optionId7,
                Character = developer,
                CharacterId = developer.Id,
                Description = "Speed Option",
                Name = "Fast",
                ParentOptionId = DevOption2.Id,
                Type = (int) OptionType.General
            };

            var DevSubOption3 = new Option
            {
                Id = optionId8,
                Character = developer,
                CharacterId = developer.Id,
                Description = "Speed Option",
                Name = "Normal",
                ParentOptionId = DevOption2.Id,
                Type = (int) OptionType.General
            };

            var DevSubOption4 = new Option
            {
                Id = optionId9,
                Character = developer,
                CharacterId = developer.Id,
                Description = "Speed Option",
                Name = "Slow",
                ParentOptionId = DevOption2.Id,
                Type = (int) OptionType.General
            };

            var DevOption3 = new Option
            {
                Id = optionId10,
                Character = developer,
                CharacterId = developer.Id,
                Description = "Level for developer",
                Name = "Level",
                ParentOptionId = null,
                Type = (int) OptionType.General
            };

            var DevSubOption5 = new Option
            {
                Id = optionId11,
                Character = developer,
                CharacterId = developer.Id,
                Description = "Level Option",
                Name = "Junior",
                ParentOptionId = DevOption3.Id,
                Type = (int) OptionType.General
            };

            var DevSubOption6 = new Option
            {
                Id = optionId12,
                Character = developer,
                CharacterId = developer.Id,
                Description = "Level Option",
                Name = "Senior",
                ParentOptionId = DevOption3.Id,
                Type = (int) OptionType.General
            };

            context.Characters.AddRange(
                panda,
                developer
            );

            context.Options.AddRange(
                PandaOption1,
                PandaSubOption1,
                PandaSubOption2,
                DevOption1,
                DevOption2,
                DevOption3,
                DevSubOption1,
                DevSubOption2,
                DevSubOption3,
                DevSubOption4,
                DevSubOption5,
                DevSubOption6
            );

            context.SaveChanges();
        }
    }
}