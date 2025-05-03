using MenuAPI.Models.Context;
using MenuAPI.Models.Entities;
using MenuAPI.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace MenuAPI.Repositories.Inplementations
{
    public class FoodTypeRepository : IFoodTypeRepository
    {
        private readonly ApplicationDbContext _context;

        public FoodTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FoodType>> GetAllAsync()
        {
            return await _context.FoodTypes
                .Include(ft => ft.Foods)
                .ToListAsync();
        }

        public async Task<FoodType?> GetByIdAsync(int id)
        {
            return await _context.FoodTypes
                .Include(ft => ft.Foods)
                .FirstOrDefaultAsync(ft => ft.IdFoodType == id);
        }

        public async Task<FoodType> CreateAsync(FoodType foodType)
        {
            await _context.FoodTypes.AddAsync(foodType);
            await _context.SaveChangesAsync();
            return foodType;
        }

        public async Task<FoodType> UpdateAsync(FoodType foodType)
        {
            var existingEntity = await _context.FoodTypes.FindAsync(foodType.IdFoodType);
            if (existingEntity != null)
            {
                _context.Entry(existingEntity).State = EntityState.Detached;
            }

            _context.FoodTypes.Update(foodType);
            await _context.SaveChangesAsync();
            return foodType;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var foodtype = await _context.FoodTypes.FindAsync(id);
            if (foodtype == null)
            {
                return false;
            }
            _context.FoodTypes.Remove(foodtype);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.FoodTypes.AnyAsync(ft => ft.IdFoodType == id);
        }

        public async Task<bool> NameFoodTypeExistsAsync(string nameFoodType, int? idFoodType = null)
        {
            return await _context.FoodTypes
                .AnyAsync(ft => ft.NameFoodType.ToLower() == nameFoodType.ToLower() && (!idFoodType.HasValue || ft.IdFoodType != idFoodType.Value));
        }
    }
}