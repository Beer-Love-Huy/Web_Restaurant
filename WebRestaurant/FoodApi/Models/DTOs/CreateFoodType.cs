using System.ComponentModel.DataAnnotations;

namespace FoodApi.Models.DTOs
{
    public class CreateFoodType
    {
        [Required (ErrorMessage = "NameFoodType is required")]
        [StringLength(50, ErrorMessage = "NameFoodType must be less than 50 characters")]
        public string NameFoodType { get; set; } = string.Empty;
    }
}