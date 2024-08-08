using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.OrderAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Persistent.Ef.OrderAgg
{
    internal class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders", "order");

            builder.HasKey(b => b.Id);
            builder.HasIndex(b => b.UserId);
            //یک به چند
            builder.OwnsMany(b => b.Items, option =>
            {
                option.ToTable("Items", "order");
                option.HasKey(b => b.Id);
                option.HasIndex(b => b.InventoryId);
                option.HasIndex(b => b.OrderId);
            });
            // ارتباط اوردر با آدرس یک به یک هست
            builder.OwnsOne(b => b.Address, option =>
            {
                option.HasKey(b => b.Id);
                option.ToTable("Addresses", "order");

                option.Property(b => b.Province)
                    .IsRequired().HasMaxLength(100);

                option.Property(b => b.City)
                    .IsRequired().HasMaxLength(100);

                option.Property(b => b.Name)
                    .IsRequired().HasMaxLength(50);

                option.Property(b => b.Family)
                    .IsRequired().HasMaxLength(50);

                option.Property(b => b.PhoneNumber)
                    .IsRequired().HasMaxLength(12);

                option.Property(b => b.NationalCode)
                    .IsRequired().HasMaxLength(10);

                option.Property(b => b.PostalCode)
                    .IsRequired().HasMaxLength(10);
            });
            //ولیو آبجکت
            builder.OwnsOne(b => b.Discount, option =>
            {
                option.Property(b => b.DiscountTitle)
                    .IsRequired()
                    .HasMaxLength(100);
            });
            //ولیو آبجکت
            builder.OwnsOne(b => b.ShippingMethod, option =>
            {
                option.Property(b => b.ShippingType)
                    .IsRequired(false)
                    .HasMaxLength(100);
            });
        }
    }
}
