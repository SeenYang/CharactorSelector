using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CharactorSelectorApi.Models;
using CharactorSelectorApi.Models.Dtos;
using CharactorSelectorApi.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NLog;
using ILogger = NLog.ILogger;

namespace CharactorSelectorApi.Repository
{
    public class CharacterRepository : ICharacterRepository
    {
        private readonly ChracterSelectorContext _context;
        private readonly IMapper _map;
        private readonly ILogger<CharacterRepository> _logger;

        public CharacterRepository(ChracterSelectorContext context, IMapper map, ILogger<CharacterRepository> logger)
        {
            _context = context;
            _map = map;
            _logger = logger;
        }

        public async Task<List<CharacterDto>> GetAllCharacters()
        {
            var entities = await _context.Characters.ToListAsync();
            var result = _map.Map<List<Character>, List<CharacterDto>>(entities);
            return result;
        }

        public async Task<CharacterDto> GetCharacterById(Guid characterId)
        {
            var entity = await _context.Characters.FirstOrDefaultAsync(c => c.Id == characterId);
            var result = _map.Map<Character, CharacterDto>(entity);
            return result;
        }

        public async Task<CharacterDto> GetCharacterByName(string name)
        {
            var entity = await _context.Characters.FirstOrDefaultAsync(c => c.Name == name);
            var result = _map.Map<Character, CharacterDto>(entity);
            return result;
        }

        public async Task<CharacterDto> CreateCharacter(CharacterDto newCharacter)
        {
            try
            {
                var entity = _map.Map<CharacterDto, Character>(newCharacter);
                var created = await _context.Characters.AddAsync(entity);
                await _context.SaveChangesAsync();
                var result = _map.Map<Character, CharacterDto>(created.Entity);
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                _logger.LogError($"Fail to create new character. Exception: {e}");
            }

            return null;
        }

        public async Task<CharacterDto> UpdateCharacter(CharacterDto character)
        {
            try
            {
                var entity = _map.Map<CharacterDto, Character>(character);
                var created = _context.Characters.Update(entity);
                await _context.SaveChangesAsync();
                var result = _map.Map<Character, CharacterDto>(created.Entity);
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                _logger.LogError($"Fail to update character {character.Id}. Exception: {e}");
            }

            return null;
        }

        public async Task<List<OptionDto>> GetOptionsByCharacterId(Guid characterId)
        {
            var entities = await _context.Options.Where(o => o.CharacterId == characterId).ToListAsync();
            var result = _map.Map<List<Option>, List<OptionDto>>(entities);
            return result;
        }

        public async Task<OptionDto> CreateOption(OptionDto newOption)
        {
            try
            {
                var entity = _map.Map<OptionDto, Option>(newOption);
                var created = await _context.Options.AddAsync(entity);
                await _context.SaveChangesAsync();
                var result = _map.Map<Option, OptionDto>(created.Entity);
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                _logger.LogError($"Fail to update new option. Exception: {e}");
            }

            return null;
        }

        public async Task<OptionDto> UpdateOption(OptionDto option)
        {
            try
            {
                var entity = _map.Map<OptionDto, Option>(option);
                var created = _context.Options.Update(entity);
                await _context.SaveChangesAsync();
                var result = _map.Map<Option, OptionDto>(created.Entity);
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                _logger.LogError($"Fail to update Option {option.Id}. Exception: {e}");
            }

            return null;
        }
    }
}