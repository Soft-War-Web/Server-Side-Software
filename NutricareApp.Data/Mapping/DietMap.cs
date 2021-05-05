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
    public class DietMap : IEntityTypeConfiguration<Diet>
    {
        public void Configure(EntityTypeBuilder<Diet> builder)
        {
            builder.ToTable("diet")
                .HasKey(c => c.DietId);
            builder.Property(c => c.DietId)
                .HasColumnName("diet_id");
            builder.Property(c => c.DietName)
                .HasColumnName("name")
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsUnicode(false);
            builder.Property(c => c.DietDescription)
                .HasColumnName("description")
                .HasColumnType("varchar")
                .HasMaxLength(500)
                .IsUnicode(false);
            builder.Property(c => c.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("DateTime");
        }
    }
}
