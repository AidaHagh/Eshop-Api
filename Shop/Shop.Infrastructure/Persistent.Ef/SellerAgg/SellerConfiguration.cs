using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.SellerAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Persistent.Ef.SellerAgg
{
    internal class SellerConfiguration : IEntityTypeConfiguration<Seller>
    {
        public void Configure(EntityTypeBuilder<Seller> builder)
        {
            builder.ToTable("Sellers", "seller");
            builder.HasIndex(b => b.NationalCode).IsUnique();

            builder.Property(s=>s.ShopName).IsRequired();
            builder.Property(s=>s.NationalCode).IsRequired();

            builder.OwnsMany(s => s.Inventories, option =>
            {
                option.ToTable("Inventories", "seller");
                option.HasKey(s=>s.Id);
                option.HasIndex(s=>s.ProductId);
                option.HasIndex(s=>s.SellerId);
            });
        }
    }
}
