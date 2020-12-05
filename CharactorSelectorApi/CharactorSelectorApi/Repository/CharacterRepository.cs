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

namespace CharactorSelectorApi.Repository
{
    public class CharacterRepository : ICharacterRepository
    {
        private readonly ChracterSelectorContext _context;
        private readonly ILogger<CharacterRepository> _logger;
        private readonly IMapper _map;

        public CharacterRepository(ChracterSelectorContext context, IMapper map, ILogger<CharacterRepository> logger)
        {
            _context = context;
            _map = map;
            _logger = logger;
        }

        /// <summary>
        ///     This method won't return characters' options
        /// </summary>
        /// <returns></returns>
        public async Task<List<CharacterDto>> GetAllCharacters()
        {
            var entities = await _context.Characters.ToListAsync();
            var result = _map.Map<List<Character>, List<CharacterDto>>(entities);
            return result;
        }

        /// <summary>
        ///     This method will return whole structure of the character's options
        /// </summary>
        /// <returns></returns>
        public async Task<CharacterDto> GetCharacterById(Guid characterId, bool includeOption = true)
        {
            var entity = await _context.Characters.FirstOrDefaultAsync(c => c.Id == characterId);
            if (entity == null) return null;
            var result = _map.Map<Character, CharacterDto>(entity);
            result.Options = new List<OptionDto>();
            if (includeOption) result.Options = await GetOptionsByCharacterId(result.Id);
            return result;
        }

        /// <summary>
        ///     This method only for validation the character's name exist or not.
        ///     Need to be extended if another requirement come in.
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Character without options' hierarchy.</returns>
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

                // todo: Ask for lock release

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
                // todo: Ask for lock release

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
            if (!entities.Any()) return new List<OptionDto>();
            // Build hierarchy
            var topOptions = entities.Where(o => o.ParentOptionId == null).ToList();
            return topOptions.Select(option => BuildOptionDto(option.Id, entities)).ToList();
        }

        private OptionDto BuildOptionDto(Guid Id, List<Option> options)
        {
            var currentOption = options.FirstOrDefault(o => o.Id == Id);
            if (currentOption == null) throw new Exception($"Can not find option {Id} from provided list.");

            var dto = _map.Map<Option, OptionDto>(currentOption);
            // TODO: Turn on automapper initialise dest when null.
            dto.SubOptions = new List<OptionDto>();
            var subOptions = options.Where(o => o.ParentOptionId == Id).ToList();

            if (subOptions.Any())
                foreach (var subOption in subOptions)
                    dto.SubOptions.Add(BuildOptionDto(subOption.Id, options));

            return dto;
        }

        public async Task<bool> CreateOptions(List<OptionDto> newOptions)
        {
            try
            {
                // Due to the input is hierarchy structured, we want to keep the relationship.
                var entities = _map.Map<List<OptionDto>, List<Option>>(newOptions);
                // todo: Ask for lock release
                await _context.Options.AddRangeAsync(entities);
                _context.Options.FromSqlRaw("SET IDENTITY_INSERT dbo.Employees ON");
                await _context.SaveChangesAsync();
                _context.Options.FromSqlRaw("SET IDENTITY_INSERT dbo.Employees OFF");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                _logger.LogError($"Fail to update new option. Exception: {e}");
                return false;
            }
        }

        public async Task<OptionDto> UpdateOption(OptionDto option)
        {
            try
            {
                var entity = _map.Map<OptionDto, Option>(option);
                // todo: Ask for lock release
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

        public async Task<CustomiseCharacterDto> GetCustomiseById(Guid CustomiseId)
        {
            var entity = await _context.Customises.FirstOrDefaultAsync(c => c.Id == CustomiseId);
            if (entity == null) return null;
            var options = await _context.CustomiseOptions
                .Where(o => o.CustomiseId == entity.Id)
                .Select(t => t.OptionId)
                .ToListAsync();
            var result = _map.Map<CustomiseCharacter, CustomiseCharacterDto>(entity);
            result.SelectedOptions = options;
            return result;
        }

        public async Task<List<CustomiseCharacterDto>> GetAllCustomise()
        {
            var entities = await _context.Customises.ToListAsync();
            var result = _map.Map<List<CustomiseCharacter>, List<CustomiseCharacterDto>>(entities);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newCustomise"></param>
        /// <returns></returns>
        public async Task<CustomiseCharacterDto> CreateCustomise(CustomiseCharacterDto newCustomise)
        {
            try
            {
                var entity = _map.Map<CustomiseCharacterDto, CustomiseCharacter>(newCustomise);
                entity.Id = Guid.NewGuid();
                if (newCustomise.SelectedOptions.Any())
                {
                    var options = (
                        from option in newCustomise.SelectedOptions
                        where !option.Equals(Guid.Empty)
                        select new CustomiseOption {CustomiseId = entity.Id, OptionId = option}
                    ).ToList();

                    await _context.CustomiseOptions.AddRangeAsync(options);
                }

                // todo: Ask for lock release
                var created = await _context.Customises.AddAsync(entity);
                _context.Options.FromSqlRaw("SET IDENTITY_INSERT dbo.Employees ON");
                await _context.SaveChangesAsync();
                _context.Options.FromSqlRaw("SET IDENTITY_INSERT dbo.Employees OFF");
                var result = _map.Map<CustomiseCharacter, CustomiseCharacterDto>(created.Entity);
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                _logger.LogError($"Fail to create new customise character. Exception: {e}");
            }

            return null;
        }
    }
}