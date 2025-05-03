using System.ComponentModel.DataAnnotations;

namespace MenuAPI.Models.DTOs
{
    public class CreateFoodTypeDto
    {
        public string NameFoodType { get; set; } = string.Empty;
    }
}