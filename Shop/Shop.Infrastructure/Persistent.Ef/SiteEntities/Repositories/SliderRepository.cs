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

namespace Shop.Infrastructure.Persistent.Ef.SiteEntities.Repositories;

internal class SliderRepository : BaseRepository<Slider>, ISliderRepository
{
    public SliderRepository(ShopContext context) : base(context)
    {
    }

    public void Delete(Slider slider)
    {
        Context.Sliders.Remove(slider);
    }
}
