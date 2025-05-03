using MenuAPI.Models.DTOs;
using MenuAPI.Models.Entities;

namespace MenuAPI.Repositories.Interface

{
    public interface IFoodRepository
    {
        Task<IEnumerable<Food>> GetAllAsync();

        Task<Food> GetByIdAsync(int id);

        Task<IEnumerable<Food>> GetByIdFoodTypeAsync(int idFoodFype);

        Task<Food> CreateAsync(Food food);

        Task<Food> UpdateAsync(Food food);

        Task<bool> DeleteAsync(int id);

        Task<bool> ExistsAsync(int id);

        Task<bool> NameFoodExistsAsync(string nameFood, int? idFood = null);
    }
}