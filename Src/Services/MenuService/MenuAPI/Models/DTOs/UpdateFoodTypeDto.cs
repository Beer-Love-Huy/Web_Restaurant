using System.ComponentModel.DataAnnotations;

namespace MenuAPI.Models.DTOs
{
    public class UpdateFoodTypeDto
    {
        public int IdFoodType { get; set; }

        public string NameFoodType { get; set; } = string.Empty;
    }
}