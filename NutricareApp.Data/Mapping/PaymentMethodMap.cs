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
    public class PaymentMethodMap : IEntityTypeConfiguration<PaymentMethod>
    {
        public void Configure(EntityTypeBuilder<PaymentMethod> builder)
        {
            builder.ToTable("payment_method")
                .HasKey(c => c.PaymentMethodId);
            builder.Property(c => c.PaymentMethodId)
                .HasColumnName("payment_method_id");
            builder.Property(c => c.CardType)
                .HasColumnName("card_type")
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsUnicode(false);
            builder.Property(c => c.ExpirationDateMonth)
                .HasColumnName("expiration_date_month");
            builder.Property(c => c.ExpirationDateYear)
                .HasColumnName("expiration_date_year");
            builder.Property(c => c.CardNumber)
                .HasColumnName("card_number");
            builder.Property(c => c.SecurityCode)
                .HasColumnName("security_code");
            builder.Property(c => c.OwnerFirstName)
                .HasColumnName("owner_first_name")
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(c => c.OwnerLastName)
                .HasColumnName("owner_last_name")
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(c => c.City)
                .HasColumnName("city")
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsUnicode(false);
            builder.Property(c => c.BillingAddress)
                .HasColumnName("billing_address")
                .HasColumnType("varchar")
                .HasMaxLength(200)
                .IsUnicode(false);
            builder.Property(c => c.BillingAddressLine2)
                .HasColumnName("billing_address_line2")
                .HasColumnType("varchar")
                .HasMaxLength(200)
                .IsUnicode(false);
            builder.Property(c => c.PostalCode)
                .HasColumnName("postal_code")
                .HasColumnType("varchar")
                .HasMaxLength(20)
                .IsUnicode(false);
            builder.Property(c => c.Country)
                .HasColumnName("country")
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsUnicode(false);
            builder.Property(c => c.PhoneNumber)
                .HasColumnName("phone_number");
            builder.HasOne<Client>(c => c.Client)
                .WithMany(c => c.PaymentMethods)
                .HasForeignKey(c => c.ClientId)
                .HasConstraintName("fk_client_id2")
                .IsRequired(true);
        }
    }
}
