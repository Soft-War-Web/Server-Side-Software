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
    public class SpecialtyMap : IEntityTypeConfiguration<Specialty>
    {

        public void Configure(EntityTypeBuilder<Specialty> builder)
        {
            builder.ToTable("specialty")
                .HasKey(c => c.SpecialtyId);
            builder.Property(c => c.SpecialtyId)
                .HasColumnName("specialty_id");
            builder.Property(c => c.SpecialtyName)
                .HasColumnName("name")
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsUnicode(false);
            builder.Property(c => c.InstitutionName)
                .HasColumnName("description")
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsUnicode(false);

        }

    }
}
