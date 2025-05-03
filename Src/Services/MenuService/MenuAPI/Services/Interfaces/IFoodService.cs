using MenuAPI.Models.DTOs;

namespace MenuAPI.Services.Interfaces
{
    public interface IFoodService
    {
        Task<IEnumerable<FoodDto>> GetAllAsync();

        Task<FoodDto> GetByIdAsync(int id);

        Task<IEnumerable<FoodDto>> GetByIdFoodTypeAsync(int idfoodtype);

        Task<FoodDto> CreateAsync(CreateFoodDto createFoodDto);

        Task<FoodDto> UpdateAsync(int id,UpdateFoodDto updateFoodDto);

        Task<bool> DeleteAsync(int id);
    }
}