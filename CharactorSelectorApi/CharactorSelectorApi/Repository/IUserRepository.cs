using System;
using System.Threading.Tasks;
using CharactorSelectorApi.Models.Dtos;

namespace CharactorSelectorApi.Repository
{
    public interface IUserRepository
    {
        public Task<UserDto> GetUserById(Guid id);
        public Task<UserDto> CreateUser(UserDto newUser);
    }
}