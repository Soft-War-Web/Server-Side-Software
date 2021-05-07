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
    public class NutritionistMap : IEntityTypeConfiguration<Nutritionist>
    {
        public void Configure(EntityTypeBuilder<Nutritionist> builder)
        {
            builder.ToTable("nutritionist")
                .HasKey(c => c.NutritionistId);
            builder.Property(c => c.NutritionistId)
                .HasColumnName("nutritionist_id");
            builder.Property(c => c.Username)
                .HasColumnName("username")
                .HasColumnType("varchar")
                .HasMaxLength(16)
                .IsUnicode(false);
            builder.Property(c => c.Password)
                .HasColumnName("password")
                .HasColumnType("char")
                .HasMaxLength(60)
                .IsUnicode(false);
            builder.Property(c => c.FirstName)
                .HasColumnName("firstname")
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsUnicode(false);
            builder.Property(c => c.LastName)
                .HasColumnName("lastname")
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsUnicode(false);
            builder.Property(c => c.Email)
                .HasColumnName("email")
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsUnicode(false);
            builder.Property(c => c.CnpNumber)
                .HasColumnName("cnp_number")
                .HasColumnType("int")
                .HasMaxLength(6)
                .IsUnicode(false);
            builder.Property(c => c.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("DateTime");
            /*builder.HasOne<Professionalprofile>(c => c.ProfessionalProfile)
                .WithOne(c => c.Nutritionist)
                .HasForeignKey<Professionalprofile>(c => c.ProfessionalprofileId)
                .HasConstraintName("fk_professional_id")
                .IsRequired(true);*/
        }
    }
}
