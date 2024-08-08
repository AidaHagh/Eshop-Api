using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.RoleAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Persistent.Ef.RoleAgg
{
    internal class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles", "role");

            builder.Property(r => r.Title).IsRequired().HasMaxLength(60);

            builder.OwnsMany(r => r.Permissions, option =>
            {
                option.ToTable("Permissions", "role");
            });


        }
    }
}
