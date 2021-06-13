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
    public class DietRecipeMap : IEntityTypeConfiguration<DietRecipe>
    {
        public void Configure(EntityTypeBuilder<DietRecipe> builder)
        {
            builder.ToTable("diet_recipe")
                .HasKey(c => new { c.DietId, c.RecipeId });
            builder.HasOne<Diet>(c => c.Diet)
                .WithMany(c => c.DietRecipes)
                .HasForeignKey(c => c.DietId);
            builder.HasOne<Recipe>(c => c.Recipe)
                .WithMany(c => c.DietRecipes)
                .HasForeignKey(c => c.RecipeId);
        }
    }
}
