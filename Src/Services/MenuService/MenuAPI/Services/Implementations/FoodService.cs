using System.Runtime.CompilerServices;
using AutoMapper;
using MenuAPI.Infrastructure.Exceptions;
using MenuAPI.Models.DTOs;
using MenuAPI.Models.Entities;
using MenuAPI.Repositories.Interface;
using MenuAPI.Services.Interfaces;
using MenuAPI.Validators.FoodValidators;

namespace MenuAPI.Services.Implementations
{
    public class FoodService : IFoodService
    {
        private readonly IFoodRepository _foodRepository;
        private readonly IFoodTypeRepository _foodTypeRepository;
        private readonly IMapper _mapper;

        public FoodService(IFoodRepository foodRepository, IFoodTypeRepository foodTypeRepository, IMapper mapper)
        {
            _foodRepository = foodRepository;
            _foodTypeRepository = foodTypeRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FoodDto>> GetAllAsync()
        {
            var foods = await _foodRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<FoodDto>>(foods);
        }

        public async Task<FoodDto> GetByIdAsync(int id)
        {
            var food = await _foodRepository.GetByIdAsync(id);
            if (food == null)
            {
                throw new NotFoundException(NotFoundException.IdFoodNotFoundMessage);
            }
            return _mapper.Map<FoodDto>(food);
        }

        public async Task<IEnumerable<FoodDto>> GetByIdFoodTypeAsync(int idFoodType)
        {
            var foods = await _foodRepository.GetByIdFoodTypeAsync(idFoodType);
            if (!foods.Any())
            {
                throw new NotFoundException(NotFoundException.IdFoodTypeNotFoundMessage);
            }
            return _mapper.Map<IEnumerable<FoodDto>>(foods);
        }

        public async Task<FoodDto> CreateAsync(CreateFoodDto createFoodDto)
        {
            var validator = new CreateFoodDtoValidator();
            var validatorResult = await validator.ValidateAsync(createFoodDto);
            if (!validatorResult.IsValid)
            {
                throw new ValidationException(validatorResult.Errors);
            }
            if(await _foodRepository.NameFoodExistsAsync(createFoodDto.NameFood))
            {
                throw new BadRequestException(BadRequestException.NameFoodAreadyExistsMessage);
            }
            if (!await _foodTypeRepository.ExistsAsync(createFoodDto.IdFoodType))
            {
                throw new NotFoundException(NotFoundException.IdFoodTypeNotFoundMessage);
            }
            var foodEntity = _mapper.Map<Food>(createFoodDto);
            var createdFood = await _foodRepository.CreateAsync(foodEntity);
            return _mapper.Map<FoodDto>(createdFood);
        }

        public async Task<FoodDto> UpdateAsync(int id, UpdateFoodDto updateFoodDto)
        {
            var validator = new UpdateFoodDtoValidator();
            var validatorResult = await validator.ValidateAsync(updateFoodDto);
            if (!validatorResult.IsValid)
            {
                throw new ValidationException(validatorResult.Errors);
            }
            if (id != updateFoodDto.IdFood)
            {
                throw new BadRequestException(BadRequestException.IdFoodMismatchMessage);
            }
            var food = await _foodRepository.GetByIdAsync(id);
            if (food == null)
            {
                throw new NotFoundException(NotFoundException.IdFoodNotFoundMessage);
            }
            if(await _foodRepository.NameFoodExistsAsync(updateFoodDto.NameFood,id))
            {
                throw new BadRequestException(BadRequestException.NameFoodAreadyExistsMessage);
            }
            if (!await _foodTypeRepository.ExistsAsync(updateFoodDto.IdFoodType))
            {
                throw new NotFoundException(NotFoundException.IdFoodTypeNotFoundMessage);
            }

            _mapper.Map(updateFoodDto,food);
            var updatedFood = await _foodRepository.UpdateAsync(food);
            return _mapper.Map<FoodDto>(updatedFood);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var food = await _foodRepository.GetByIdAsync(id);
            if (food == null)
            {
                throw new NotFoundException(NotFoundException.IdFoodNotFoundMessage);
            }

            return await _foodRepository.DeleteAsync(id);
        }
    }
}

