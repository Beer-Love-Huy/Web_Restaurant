using System.ComponentModel.DataAnnotations;

namespace MenuAPI.Models.DTOs
{
    public class CreateFoodDto
    {
        public string NameFood { get; set; } = string.Empty;

        public decimal PriceFood { get; set; }

        public string ImgFood { get; set; } = string.Empty;

        public int IdFoodType { get; set; }
    }
}