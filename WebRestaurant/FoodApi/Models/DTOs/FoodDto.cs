using System.ComponentModel.DataAnnotations;

namespace FoodApi.Models.DTOs
{
    public class FoodDto
    {
        public int IdFood { get; set; }
        public string NameFood { get; set; } = string.Empty;
        public decimal PriceFood { get; set; }
        public string? UrlImgFood { get; set; }
        public int IdFoodType { get; set; }
        public string FoodTypeName { get; set; } = string.Empty;
    }
}


