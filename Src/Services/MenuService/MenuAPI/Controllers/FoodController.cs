using System.Reflection;
using MenuAPI.Models.DTOs;
using MenuAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace MenuAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FoodController : ControllerBase
    {
        private readonly IFoodService _foodService;

        public FoodController(IFoodService foodService)
        {
            _foodService = foodService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FoodDto>>> GetAll()
        {
            var foods = await _foodService.GetAllAsync();
            return Ok(foods);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FoodDto>> GetById(int id)
        {
            var food = await _foodService.GetByIdAsync(id);
            return Ok(food);
        }

        [HttpGet("type")]
        public async Task<ActionResult<IEnumerable<FoodDto>>> GetByIdFoodType([FromQuery]int idFoodType)
        {
            var foods = await _foodService.GetByIdFoodTypeAsync(idFoodType);
            return Ok(foods);
        }

        [HttpPost]
        public async Task<ActionResult<FoodDto>> Create(CreateFoodDto createFoodDto)
        {
            var createdFood = await _foodService.CreateAsync(createFoodDto);
            return CreatedAtAction(nameof(GetById), new { id = createdFood.IdFood }, createdFood);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<FoodDto>> Update(int id, UpdateFoodDto updateFoodDto)
        {
            var updatedFood = await _foodService.UpdateAsync(id, updateFoodDto);
            return Ok(updatedFood);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleteFood = await _foodService.DeleteAsync(id);
            return NoContent();
        }
    }
}

