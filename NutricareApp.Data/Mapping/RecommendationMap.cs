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
            builder.Property(c => c.Name)
                .HasColumnName("name")
                .HasMaxLength(50)
                .IsUnicode(false);
            builder.Property(c => c.Description)
               .HasColumnName("description")
               .HasMaxLength(250)
               .IsUnicode(false);
            builder.Property(c => c.CreatedAt)
               .HasColumnName("created_at");
            builder.Property(c => c.LastNotification)
               .HasColumnName("last_notification");

        }
    }
}
