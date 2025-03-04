using FoodApi.Models.Context;
using FoodApi.Models.DTOs;
using FoodApi.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FoodController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FoodDto>>> GetFoods()
        {
            try
            {
                var foods = await _context.Foods
                    .Include(f => f.FoodType)
                    .Select(f => new FoodDto
                    {
                        IdFood = f.IdFood,
                        NameFood = f.NameFood,
                        PriceFood = f.PriceFood,
                        UrlImgFood = f.UrlImgFood,
                        IdFoodType = f.IdFoodType,
                        FoodTypeName = f.FoodType.NameFoodType
                    })
                    .ToListAsync();

                return Ok(foods);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Lỗi khi lấy danh sách món ăn: {ex.Message}");
            }
        }

        // Thêm endpoint kiểm tra kết nối
        [HttpGet("test-connection")]
        public async Task<ActionResult> TestConnection()
        {
            try
            {
                // Thử kết nối đến database
                bool canConnect = await _context.Database.CanConnectAsync();
                
                if (canConnect)
                {
                    return Ok("Kết nối database thành công!");
                }
                else
                {
                    return BadRequest("Không thể kết nối đến database!");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Lỗi kết nối: {ex.Message}");
            }
        }
    }
}