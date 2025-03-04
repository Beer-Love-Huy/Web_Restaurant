using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodApi.Models.Entities
{
    public class Food
    {
        [Key]
        [Column("id_food")]
        public int IdFood { get; set; }

        [Required]
        [StringLength(100)]
        [Column("name_food")]
        public string NameFood { get; set; } = string.Empty;

        [Required]
        [Column("price_food", TypeName = "decimal(10, 2)")]
        public decimal PriceFood { get; set; }

        [StringLength(255)]
        [Column("url_img_food")]
        public string? UrlImgFood { get; set; } 

        [Required]
        [Column("id_food_type")]
        [ForeignKey("FoodType")]
        public int IdFoodType { get; set; }

        public virtual FoodType FoodType { get; set; } = null!;
    }
}