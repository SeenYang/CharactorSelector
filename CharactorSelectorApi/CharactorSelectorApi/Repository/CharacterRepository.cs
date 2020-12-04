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
        private readonly IMapper _map;
        private readonly ILogger<CharacterRepository> _logger;

        public CharacterRepository(ChracterSelectorContext context, IMapper map, ILogger<CharacterRepository> logger)
        {
            _context = context;
            _map = map;
            _logger = logger;
        }

        /// <summary>
        /// This method won't return characters' options
        /// </summary>
        /// <returns></returns>
        public async Task<List<CharacterDto>> GetAllCharacters()
        {
            var entities = await _context.Characters.ToListAsync();
            var result = _map.Map<List<Character>, List<CharacterDto>>(entities);
            return result;
        }

        /// <summary>
        ///  This method will return whole structure of the character's options
        /// </summary>
        /// <returns></returns>
        public async Task<CharacterDto> GetCharacterById(Guid characterId, bool includeOption = true)
        {
            var entity = await _context.Characters.FirstOrDefaultAsync(c => c.Id == characterId);

            if (entity == null)
            {
                return null;
            }

            var result = _map.Map<Character, CharacterDto>(entity);
            // TODO: Turn on automapper initialise dest when null.
            result.Options = new List<OptionDto>();

            if (includeOption)
            {
                result.Options = await GetOptionsByCharacterId(result.Id);
            }
            return result;
        }

        /// <summary>
        /// This method only for validation the character's name exist or not.
        /// Need to be extended if another requirement come in. 
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

            if (!entities.Any())
            {
                return new List<OptionDto>();
            }
            
            // Build hierarchy
            var topOptions = entities.Where(o => o.ParentOptionId == null).ToList();
            return topOptions.Select(option => BuildOptionDto(option.Id, entities)).ToList();
        }

        
        public async Task<OptionDto> CreateOption(OptionDto newOption)
        {
            try
            {
                var entity = _map.Map<OptionDto, Option>(newOption);
                // todo: Ask for lock release
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
        
        
        private OptionDto BuildOptionDto(Guid Id, List<Option> options)
        {
            var currentOption = options.FirstOrDefault(o => o.Id == Id);
            if (currentOption == null)
            {
                throw new Exception($"Can not find option {Id} from provided list.");
            }

            var dto = _map.Map<Option, OptionDto>(currentOption);
            // TODO: Turn on automapper initialise dest when null.
            dto.SubOptions = new List<OptionDto>();
            var subOptions = options.Where(o => o.ParentOptionId == Id).ToList();

            if (subOptions.Any())
            {
                foreach (var subOption in subOptions)
                {
                    dto.SubOptions.Add(BuildOptionDto(subOption.Id, options));
                }
            }

            return dto;
        }
    }
}