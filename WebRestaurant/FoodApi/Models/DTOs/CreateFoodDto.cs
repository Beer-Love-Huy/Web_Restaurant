using System.ComponentModel.DataAnnotations;

namespace FoodApi.Models.DTOs
{
    public class CreateFoodDto
    {
        [Required(ErrorMessage = "NameFood is required")]
        [StringLength(100, ErrorMessage = "NameFood must be less than 100 characters")]
        public string NameFood { get; set; } = string.Empty;

        [Required(ErrorMessage = "PriceFood is required")]
        [Range(0, double.MaxValue, ErrorMessage = "PriceFood must be greater than 0")]
        public decimal PriceFood { get; set; }

        [StringLength(255, ErrorMessage = "UrlImgFood must be less than 255 characters")]
        public string? UrlImgFood { get; set; }

        [Required(ErrorMessage = "IdFoodType is required")]
        public int IdFoodType { get; set; }
    }
}