using System.ComponentModel.DataAnnotations;

namespace MenuAPI.Models.DTOs
{
    public class UpdateFoodDto
    {
        public int IdFood { get; set; }

        public string NameFood { get; set; } = string.Empty;

        public decimal PriceFood { get; set; }

        public string ImgFood { get; set; } = string.Empty;

        public int IdFoodType { get; set; }
    }
}