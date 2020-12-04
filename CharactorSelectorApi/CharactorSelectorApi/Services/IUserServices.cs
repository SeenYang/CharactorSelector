using System;
using System.Threading.Tasks;
using CharactorSelectorApi.Models.Dtos;

namespace CharactorSelectorApi.Services
{
    public interface IUserServices
    {
        public Task<UserDto> GetUserById(Guid id);
        public Task<UserDto> CreateUser(UserDto newUser);
    }
}