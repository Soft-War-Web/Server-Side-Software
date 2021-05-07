using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NutricareApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutricareApp.Data.Mapping
{
    class RecipeMap : IEntityTypeConfiguration<Recipe>
    {
        public void Configure(EntityTypeBuilder<Recipe> builder)
        {
            builder.ToTable("recipe").HasKey(c => c.RecipeId);
            builder.Property(c => c.RecipeId).HasColumnName("category_id");
            builder.Property(c => c.NutritionistId).HasColumnName("nutritionist_id");
            builder.Property(c => c.Name).HasColumnName("name").HasMaxLength(50).IsUnicode(false);
            builder.Property(c => c.Description).HasColumnName("description").HasMaxLength(250).IsUnicode(false);
            builder.Property(c => c.Preparation).HasColumnName("preparation").HasMaxLength(500);
            builder.Property(c => c.Ingredients).HasColumnName("ingredients").HasMaxLength(500);
            builder.Property(c => c.Favorite).HasColumnName("favorite").HasColumnType("int");
            builder.Property(c => c.CreatedAt).HasColumnName("created_At").HasColumnType("DateTime");
            builder.Property(c => c.LastModification).HasColumnName("last_modification").HasColumnType("DateTime");
            //FK con nutritionist
            builder.HasOne(c => c.Nutritionist).WithMany(c => c.Recipes).HasForeignKey(c => c.NutritionistId).HasConstraintName("fk_nutritionist_recipe_id").IsRequired(true);
        }
    }
}