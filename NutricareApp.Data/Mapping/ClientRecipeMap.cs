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
    public class ClientRecipeMap : IEntityTypeConfiguration<ClientRecipe>
    {
        public void Configure(EntityTypeBuilder<ClientRecipe> builder)
        {
            builder.ToTable("client_recipe")
                .HasKey(c => new { c.ClientId , c.RecipeId });
            builder.HasOne<Client>(c => c.Client)
                .WithMany(c => c.ClientRecipes)
                .HasForeignKey(c => c.ClientId);
            builder.HasOne<Recipe>(c => c.Recipe)
                .WithMany(c => c.ClientRecipes)
                .HasForeignKey(c => c.RecipeId);
        }
    }
}