using CharactorSelectorApi.Repository;
using CharactorSelectorApi.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CharactorSelectorApi.IoC
{
    public static class DIRegistration
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICharacterRepository, CharacterRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICharacterService, CharacterService>();
            services.AddScoped<ICustomiseService, CustomiseService>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}