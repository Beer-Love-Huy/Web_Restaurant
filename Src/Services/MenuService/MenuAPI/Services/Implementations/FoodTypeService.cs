using AutoMapper;
using MenuAPI.Infrastructure.Exceptions;
using MenuAPI.Models.DTOs;
using MenuAPI.Models.Entities;
using MenuAPI.Repositories.Interface;
using MenuAPI.Services.Interfaces;
using MenuAPI.Validators.FoodTypeValidators;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MenuAPI.Services.Implementations
{
    public class FoodTypeService : IFoodTypeService
    {
        private readonly IFoodTypeRepository _foodTypeRepository;
        private readonly IMapper _mapper;

        public FoodTypeService(IFoodTypeRepository foodTypeRepository, IMapper mapper)
        {
            _foodTypeRepository = foodTypeRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FoodTypeDto>> GetAllAsync()
        {
            var foodtypes = await _foodTypeRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<FoodTypeDto>>(foodtypes);
        }

        public async Task<FoodTypeDto> GetByIdAsync(int id)
        {
            var food = await _foodTypeRepository.GetByIdAsync(id);
            if(food == null)
            {
                throw new NotFoundException(NotFoundException.IdFoodTypeNotFoundMessage);
            }
            return _mapper.Map<FoodTypeDto>(food);
        }

        public async Task<FoodTypeDto> CreateAsync(CreateFoodTypeDto createFoodTypeDto)
        {
            var validator = new CreateFoodTypeDtoValidator();
            var validatorResult = await validator.ValidateAsync(createFoodTypeDto);
            if (!validatorResult.IsValid)
            {
                throw new ValidationException(validatorResult.Errors);
            }
            if (await _foodTypeRepository.NameFoodTypeExistsAsync(createFoodTypeDto.NameFoodType))
            {
                throw new BadRequestException(BadRequestException.NameFoodTypeAreadyExistsMessage);
            }
            var foodTypeEntity = _mapper.Map<FoodType>(createFoodTypeDto);
            var createdFoodType = await _foodTypeRepository.CreateAsync(foodTypeEntity);
            return _mapper.Map<FoodTypeDto>(createdFoodType); 
        }

        public async Task<FoodTypeDto> UpdateAsync(int id,UpdateFoodTypeDto updateFoodTypeDto)
        {
            var validator = new UpdateFoodTypeDtoValidator();
            var validatorResult = await validator.ValidateAsync(updateFoodTypeDto);
            if (!validatorResult.IsValid)
            {
                throw new ValidationException(validatorResult.Errors);
            }
            if (id != updateFoodTypeDto.IdFoodType)
            {
                throw new BadRequestException(BadRequestException.IdFoodTypeMismatchMessage);
            }
            if(await _foodTypeRepository.NameFoodTypeExistsAsync(updateFoodTypeDto.NameFoodType, id))
            {
                throw new BadRequestException(BadRequestException.NameFoodTypeAreadyExistsMessage);
            }
            var foodtype = await _foodTypeRepository.GetByIdAsync(id);
            if(foodtype == null)
            {
                throw new NotFoundException(NotFoundException.IdFoodTypeNotFoundMessage);
            }

            var foodTypeEntity = _mapper.Map<FoodType>(updateFoodTypeDto); 
            foodTypeEntity.IdFoodType = id;
            var updatedFood = await _foodTypeRepository.UpdateAsync(foodTypeEntity);
            return _mapper.Map<FoodTypeDto>(updatedFood);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var foodtype = await _foodTypeRepository.GetByIdAsync(id);
            if(foodtype == null)
            {
                throw new NotFoundException(NotFoundException.IdFoodTypeNotFoundMessage);
            }
            return await _foodTypeRepository.DeleteAsync(id);
        }
    }
}
     
    