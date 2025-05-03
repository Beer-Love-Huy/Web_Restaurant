using AutoMapper;
using MenuAPI.Models.Context;
using MenuAPI.Models.DTOs;
using MenuAPI.Models.Entities;
using MenuAPI.Repositories.Interface;
using Microsoft.EntityFrameworkCore;


namespace MenuAPI.Repositories.Inplementations
{
    public class FoodRepository : IFoodRepository
    {
        private readonly ApplicationDbContext _context;

        public FoodRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Food>> GetAllAsync()
        {
            return await _context.Foods.AsNoTracking().Include(f => f.FoodType).ToListAsync();
        }


        public async Task<Food?> GetByIdAsync(int id)
        {
            return await _context.Foods
                .AsNoTracking()
                .Include(f => f.FoodType)
                .FirstOrDefaultAsync(f => f.IdFood == id);
        }

        public async Task<IEnumerable<Food>> GetByIdFoodTypeAsync(int idFoodType)
        {
            return await _context.Foods
                .AsNoTracking()
                .Include(f => f.FoodType)
                .Where(f => f.IdFoodType == idFoodType)
                .ToListAsync();
        }

        public async Task<Food> CreateAsync(Food food)
        {
            await _context.Foods.AddAsync(food);
            await _context.SaveChangesAsync();
            return food;
        }

        public async Task<Food> UpdateAsync(Food food)
        {
            _context.Foods.Update(food);
            await _context.SaveChangesAsync();
            return food;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var food = await _context.Foods.FindAsync(id);
            if (food == null)
            {
                return false;
            }
            _context.Foods.Remove(food);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Foods.AnyAsync(f => f.IdFood == id);
        }

        public async Task<bool> NameFoodExistsAsync(string nameFood, int? idFood = null)
        {
            var query = _context.Foods.AsNoTracking();

            if (idFood.HasValue)
            {
                return await query.AnyAsync(f =>
                    f.NameFood.ToLower() == nameFood.ToLower() &&
                    f.IdFood != idFood.Value);
            }

            return await query.AnyAsync(f =>
                f.NameFood.ToLower() == nameFood.ToLower());
        }
    }
}