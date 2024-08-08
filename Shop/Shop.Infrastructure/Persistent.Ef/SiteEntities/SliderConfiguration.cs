using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.SiteEntities;
using Shop.Domain.SiteEntities.IRepositories;
using Shop.Infrastructure._Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Persistent.Ef.SiteEntities;

internal class SliderConfiguration : IEntityTypeConfiguration<Slider>
{
    public void Configure(EntityTypeBuilder<Slider> builder)
    {
        builder.Property(s => s.Title)
               .HasMaxLength(120);

        builder.Property(s => s.ImageName)
               .HasMaxLength(120).IsRequired();

        builder.Property(s => s.Link)
               .HasMaxLength(500);
    }
}
