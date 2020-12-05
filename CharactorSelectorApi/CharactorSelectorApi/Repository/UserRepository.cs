using System;
using System.Threading.Tasks;
using AutoMapper;
using CharactorSelectorApi.Models;
using CharactorSelectorApi.Models.Dtos;
using CharactorSelectorApi.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CharactorSelectorApi.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ChracterSelectorContext _context;
        private readonly ILogger<UserRepository> _logger;
        private readonly IMapper _map;

        public UserRepository(ChracterSelectorContext context, IMapper map, ILogger<UserRepository> logger)
        {
            _context = context;
            _map = map;
            _logger = logger;
        }

        public async Task<UserDto> GetUserById(Guid id)
        {
            var entity = await _context.Users.FirstOrDefaultAsync(c => c.Id == id);
            if (entity == null) return null;
            return _map.Map<User, UserDto>(entity);
        }

        public async Task<UserDto> CreateUser(UserDto newUser)
        {
            try
            {
                var entity = _map.Map<UserDto, User>(newUser);
                // todo: Ask for lock release
                var created = await _context.Users.AddAsync(entity);
                await _context.SaveChangesAsync();
                var result = _map.Map<User, UserDto>(created.Entity);
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                _logger.LogError($"Fail to create new user. Exception: {e}");
            }

            return null;
        }
    }
}