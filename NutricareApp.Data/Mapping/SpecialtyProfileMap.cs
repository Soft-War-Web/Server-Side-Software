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
    public class SpecialtyProfileMap : IEntityTypeConfiguration<SpecialtyProfile>
    {
        public void Configure(EntityTypeBuilder<SpecialtyProfile> builder)
        {
            builder.ToTable("specialty_professional_profile")
                .HasKey(c => new { c.SpecialtyId, c.ProfessionalProfileId });
            builder.HasOne<Specialty>(c => c.Specialty)
                .WithMany(c => c.SpecialtyProfiles)
                .HasForeignKey(c => c.SpecialtyId);
            builder.HasOne<Professionalprofile>(c => c.Professionalprofile)
                .WithMany(c => c.SpecialtyProfiles)
                .HasForeignKey(c => c.ProfessionalProfileId);      
        }
    }
}
