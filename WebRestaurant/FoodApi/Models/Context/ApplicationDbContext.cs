using FoodApi.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace FoodApi.Models.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        {
        }

        public DbSet<Food> Foods { get; set; }
        public DbSet<FoodType> FoodTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Cấu hình cho bảng FoodType
            modelBuilder.Entity<FoodType>(entity =>
            {
                entity.ToTable("FoodType");
                entity.HasKey(e => e.IdFoodType);

                entity.Property(e => e.NameFoodType)
                    .IsRequired()
                    .HasMaxLength(50);

                // Cấu hình relationship 1-n với Food
                entity.HasMany(e => e.Foods)
                    .WithOne(e => e.FoodType)
                    .HasForeignKey(e => e.IdFoodType)
                    .HasConstraintName("fk_food_type");
            });

            // Cấu hình cho bảng Food
            modelBuilder.Entity<Food>(entity =>
            {
                entity.ToTable("Food");
                entity.HasKey(e => e.IdFood);

                entity.Property(e => e.NameFood)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.PriceFood)
                    .IsRequired()
                    .HasPrecision(10, 2);

                entity.Property(e => e.UrlImgFood)
                    .HasMaxLength(255);
            });
        }
    }
} 