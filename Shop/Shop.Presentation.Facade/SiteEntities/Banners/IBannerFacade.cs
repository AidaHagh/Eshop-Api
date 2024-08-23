using Common.Application;
using Shop.Application.SiteEntities.Banners.Create;
using Shop.Application.SiteEntities.Banners.Edit;
using Shop.Query.SiteEntities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Shop.Presentation.Facade.SiteEntities.Banners;

public interface IBannerFacade
{
    Task<OperationResult>CreateBanner(CreateBannerCommand command);
    Task<OperationResult>EditBanner(EditBannerCommand command);
    Task<OperationResult>DeleteBanner(long bannerId);


    Task<BannerDto?>GetBannerById(int bannerId);   
    Task<List<BannerDto>>GetBannerList();   
}
