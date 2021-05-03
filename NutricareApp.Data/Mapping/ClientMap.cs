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
    public class ClientMap : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("client")
                .HasKey(c => c.ClientId);
            builder.Property(c => c.ClientId)
                .HasColumnName("client_id");
            builder.Property(c => c.Username)
                .HasColumnName("username")
                .HasMaxLength(16)
                .IsUnicode(false);
            builder.Property(c => c.Email)
                .HasColumnName("email")
                .HasMaxLength(50)
                .IsUnicode(false);
            builder.Property(c => c.FirstName)
                .HasColumnName("firstname")
                .HasMaxLength(50)
                .IsUnicode(false);
            builder.Property(c => c.LastName)
                .HasColumnName("lastname")
                .HasMaxLength(50)
                .IsUnicode(false);
            builder.Property(c => c.Password)
                .HasColumnName("password")
                .HasMaxLength(60)
                .IsUnicode(false);
            builder.Property(c => c.CreatedAt)
                .HasColumnName("created_at");
        }
    }
}
