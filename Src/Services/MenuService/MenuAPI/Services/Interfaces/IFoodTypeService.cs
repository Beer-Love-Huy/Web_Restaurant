using MenuAPI.Models.DTOs;

namespace MenuAPI.Services.Interfaces
{
    public interface IFoodTypeService
    {
        Task<IEnumerable<FoodTypeDto>> GetAllAsync();

        Task<FoodTypeDto> GetByIdAsync(int id);

        Task<FoodTypeDto> CreateAsync(CreateFoodTypeDto createFoodTypeDto);

        Task<FoodTypeDto> UpdateAsync(int id,UpdateFoodTypeDto updateFoodTypeDto);

        Task<bool> DeleteAsync(int id);

    }
}