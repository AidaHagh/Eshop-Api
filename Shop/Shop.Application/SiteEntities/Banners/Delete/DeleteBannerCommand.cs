using Common.Application;
using Shop.Domain.SiteEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.SiteEntities.Banners.Delete;

public record DeleteBannerCommand(long Id) : IBaseCommand;
