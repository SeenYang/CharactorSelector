using System;
using System.Threading.Tasks;
using CharactorSelectorApi.Models.Dtos;
using CharactorSelectorApi.Repository;
using Microsoft.Extensions.Logging;

namespace CharactorSelectorApi.Services
{
    public class UserService : IUserService
    {
        private readonly ILogger<UserService> _logger;
        private readonly IUserRepository _repo;

        public UserService(ILogger<UserService> logger, IUserRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public async Task<UserDto> GetUserById(Guid id)
        {
            return await _repo.GetUserById(id);
        }

        public async Task<UserDto> CreateUser(UserDto newUser)
        {
            return await _repo.CreateUser(newUser);
        }
    }
}