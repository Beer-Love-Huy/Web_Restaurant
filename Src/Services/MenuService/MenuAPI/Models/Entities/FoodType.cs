using System.ComponentModel.DataAnnotations;

namespace MenuAPI.Models.Entities
{
    public class FoodType
    {
        public int IdFoodType { get; set; }

        [Required]
        [MaxLength(50)]
        public string NameFoodType { get; set; }

        public virtual ICollection<Food> Foods { get; set; }
    }
}