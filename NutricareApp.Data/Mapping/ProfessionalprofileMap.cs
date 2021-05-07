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
    public class ProfessionalprofileMap : IEntityTypeConfiguration<Professionalprofile>
    {
        public void Configure(EntityTypeBuilder<Professionalprofile> builder)
        {
            builder.ToTable("professional_profile")
                .HasKey(c => c.ProfessionalprofileId);
            builder.Property(c => c.ProfessionalprofileId)
                .HasColumnName("professional_profile_id");
            builder.Property(c => c.ProfessionalExperienceDescription)
                .HasColumnName("professional_experience_description")
                .HasColumnType("varchar")
                .HasMaxLength(500)
                .IsUnicode(false);
            builder.HasOne<Nutritionist>(c => c.Nutritionist)
                .WithOne(c => c.ProfessionalProfile)
                .HasForeignKey<Professionalprofile>(c => c.NutritionistId)
                .HasConstraintName("fk_nutritionist_profile_id")
                .IsRequired(true);
        }
    }
}
