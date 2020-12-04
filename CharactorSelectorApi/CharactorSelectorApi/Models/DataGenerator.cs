using System;
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

            var teamId1 = Guid.NewGuid();
            var teamId2 = Guid.NewGuid();
            var gameId1 = Guid.NewGuid();
            var gameId2 = Guid.NewGuid();

            context.SaveChanges();
        }
    }
}