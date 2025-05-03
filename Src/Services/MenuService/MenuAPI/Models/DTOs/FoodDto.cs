namespace MenuAPI.Models.DTOs
{
    public class FoodDto
    {
        public int IdFood { get; set; }

        public string NameFood { get; set; } = string.Empty;

        public decimal PriceFood { get; set; }

        public string ImgFood { get; set; } = string.Empty;

        public int IdFoodType { get; set; }

        public string NameFoodType { get; set; } = string.Empty;
    }
}