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
    public class AppointmentMap : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.ToTable("appointment")
                .HasKey(c => c.AppointmentId);
            builder.Property(c => c.AppointmentId)
                .HasColumnName("appointment_id");
            builder.Property(c => c.ClientId)
                .HasColumnName("client_id");
            builder.Property(c => c.NutritionistId)
                .HasColumnName("nutritionist_id");
            builder.Property(c => c.DietId)
                .HasColumnName("diet_id");
            builder.Property(c => c.AppointmentDate)
                .HasColumnName("appointment_date")
                .HasColumnType("DateTime");
            builder.Property(c => c.NutritionistNotes)
                .HasColumnName("nutritionist_notes")
                .HasColumnType("varchar");
            builder.HasOne<Client>(c => c.Client)
                .WithMany(c => c.Appointments)
                .HasForeignKey(c => c.ClientId)
                .HasConstraintName("fk_client_id")
                .IsRequired(true);
            builder.HasOne<Nutritionist>(c => c.Nutritionist)
                .WithMany(c => c.Appointments)
                .HasForeignKey(c => c.NutritionistId)
                .HasConstraintName("fk_nutritionist_id")
                .IsRequired(true);
            builder.HasOne<Diet>(c => c.Diet)
                .WithMany(c => c.Appointments)
                .HasForeignKey(c => c.DietId)
                .HasConstraintName("fk_diet_id")
                .IsRequired(true);
        }
    }
}