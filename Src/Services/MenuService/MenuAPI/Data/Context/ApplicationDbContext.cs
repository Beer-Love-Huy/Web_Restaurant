using MenuAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace MenuAPI.Models.Context
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

            modelBuilder.Entity<FoodType>(entity =>
            {
                entity.ToTable("FoodType");
                entity.HasKey(e => e.IdFoodType);

                entity.Property(e => e.NameFoodType)
                .IsRequired()
                .HasMaxLength(50);

                entity.HasIndex(e => e.NameFoodType)
                .IsUnique();

                entity.HasMany(e => e.Foods)
                .WithOne(e => e.FoodType)
                .HasForeignKey(e => e.IdFoodType)
                .HasConstraintName("fk_food_type");
            });

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

                entity.Property(e => e.ImgFood)
                .HasMaxLength(255);
            });
        }
    }
}