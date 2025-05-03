using MenuAPI.Models.DTOs;
using MenuAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MenuAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FoodTypeController : ControllerBase
    {
        private readonly IFoodTypeService _foodTypeService;

        public FoodTypeController(IFoodTypeService foodTypeService)
        {
            _foodTypeService = foodTypeService;
        }

        /// <summary>
        /// Lấy danh sách tất cả món ăn.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FoodTypeDto>>> GetAll()
        {
            var foodTypes = await _foodTypeService.GetAllAsync();
            return Ok(foodTypes);
        }

        /// <summary>
        /// Lấy món ăn theo ID.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<FoodTypeDto>> GetById(int id)
        {
            var foodType = await _foodTypeService.GetByIdAsync(id);
            return Ok(foodType);
        }

        /// <summary>
        /// Tạo mới một món ăn.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<FoodTypeDto>> Create(CreateFoodTypeDto createFoodTypeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createdFoodType = await _foodTypeService.CreateAsync(createFoodTypeDto);
            return CreatedAtAction(nameof(GetById), new { id = createdFoodType.IdFoodType }, createdFoodType);
        }

        /// <summary>
        /// Cập nhật thông tin món ăn.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<ActionResult<FoodTypeDto>> Update(int id, UpdateFoodTypeDto updateFoodTypeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var updatedFoodType = await _foodTypeService.UpdateAsync(id, updateFoodTypeDto);
            return Ok(updatedFoodType);
        }

        /// <summary>
        /// Xóa món ăn theo ID.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletedFood = await _foodTypeService.DeleteAsync(id);
            return NoContent();

        }
    }
}
