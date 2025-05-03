using System.ComponentModel.DataAnnotations;

namespace MenuAPI.Models.Entities
{
    public class Food
    {
        public int IdFood { get; set; }

        [Required]
        [MaxLength(100)]
        public string NameFood { get; set; }

        [Required]
        public decimal PriceFood { get; set; }

        public string ImgFood { get; set; }

        public int IdFoodType { get; set; }

        [Required]
        public virtual FoodType FoodType { get; set; }
    }
}