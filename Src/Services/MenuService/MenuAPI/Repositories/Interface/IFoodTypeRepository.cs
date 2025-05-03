using MenuAPI.Models.DTOs;
using MenuAPI.Models.Entities;

namespace MenuAPI.Repositories.Interface
{
    public interface IFoodTypeRepository
    {
        Task<IEnumerable<FoodType>> GetAllAsync();

        Task<FoodType> GetByIdAsync(int id);

        Task<FoodType> CreateAsync(FoodType foodType);

        Task<FoodType> UpdateAsync(FoodType foodType);

        Task<bool> DeleteAsync(int id);

        Task<bool> ExistsAsync(int id);

        Task<bool> NameFoodTypeExistsAsync(string nameFoodType, int? idFoodType = null);
    }
}