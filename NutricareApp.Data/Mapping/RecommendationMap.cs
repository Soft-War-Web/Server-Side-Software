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
    public class RecommendationMap : IEntityTypeConfiguration<Recommendation>
    {
        public void Configure(EntityTypeBuilder<Recommendation> builder)
        {
            builder.ToTable("recommendation")
                .HasKey(c => c.RecommendationId);
            builder.Property(c => c.RecommendationId)
                .HasColumnName("recommendation_id");
            builder.Property(c => c.NutritionistId)
                .HasColumnName("nutritionist_id");
            builder.Property(c => c.Name)
                .HasColumnName("name")
                .HasMaxLength(50)
                .IsUnicode(false);
            builder.Property(c => c.Description)
               .HasColumnName("description")
               .HasMaxLength(250)
               .IsUnicode(false);
            builder.Property(c => c.CreatedAt)
               .HasColumnName("created_at")
               .HasColumnType("DateTime");
            builder.Property(c => c.LastModification)
               .HasColumnName("last_modification")
               .HasColumnType("DateTime");
            builder.HasOne(c => c.Nutritionist)
                .WithMany(c => c.Recommendations)
                .HasForeignKey(c => c.NutritionistId)
                .HasConstraintName("fk_nutritionist_recommendation_id")
                .IsRequired(true);
        }
    }
}
