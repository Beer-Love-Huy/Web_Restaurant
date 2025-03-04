using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodApi.Models.Entities
{
    public class FoodType
    {
        [Key]
        [Column("id_food_type")]
        public int IdFoodType { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("name_food_type")]
        public string NameFoodType { get; set; } = string.Empty;

        public virtual ICollection<Food> Foods { get; set; } = new List<Food>();
    }
}