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
    public class BillMap : IEntityTypeConfiguration<Bill>
    {
        public void Configure(EntityTypeBuilder<Bill> builder)
        {
            builder.ToTable("bill")
                .HasKey(c => c.BillId);
            builder.Property(c => c.BillId)
                .HasColumnName("bill_id");
            builder.Property(c => c.BillDate)
                .HasColumnName("bill_date")
                .HasColumnType("DateTime");
            builder.Property(c => c.Amount)
                .HasColumnName("amount")
                .HasColumnType("decimal");
            builder.Property(c => c.Ruc)
                .HasColumnName("ruc");
            builder.HasOne<Client>(c => c.Client)
                .WithMany(c => c.Bills)
                .HasForeignKey(c => c.ClientId)
                .HasConstraintName("fk_client_id3")
                .IsRequired(true);
        }
    }
}
