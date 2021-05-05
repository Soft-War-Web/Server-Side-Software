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
    class ProfessionalprofileMap : IEntityTypeConfiguration<Professionalprofile>
    {
        public void Configure(EntityTypeBuilder<Professionalprofile> builder)
        {
            builder.ToTable("professional_profile")
                .HasKey(c => c.ProfessionaprofileId);
            builder.Property(c => c.ProfessionaprofileId)
                    .HasColumnName("professionalprifile_if");
            builder.Property(c => c.ProfessionalExperienceDescription)
                    .HasColumnName("professional_experience_descriptopn")
                    .HasColumnType("varchar")
                    .HasMaxLength(500)
                    .IsUnicode(false);
        }
    }
}
