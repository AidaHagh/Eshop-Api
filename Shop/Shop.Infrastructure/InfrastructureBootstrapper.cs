using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shop.Domain.CategoryAgg.IRepository;
using Shop.Domain.CommentAgg.IRepository;
using Shop.Domain.OrderAgg.IRepository;
using Shop.Domain.ProductAgg.IRepository;
using Shop.Domain.RoleAgg.IRepository;
using Shop.Domain.SellerAgg.IRepository;
using Shop.Domain.SiteEntities.IRepositories;
using Shop.Domain.UserAgg.IRepository;
using Shop.Infrastructure.Persistent.Ef.CategoryAgg;
using Shop.Infrastructure.Persistent.Ef.CommentAgg;
using Shop.Infrastructure.Persistent.Ef.OrderAgg;
using Shop.Infrastructure.Persistent.Ef.ProductAgg;
using Shop.Infrastructure.Persistent.Ef.RoleAgg;
using Shop.Infrastructure.Persistent.Ef.SellerAgg;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Infrastructure.Persistent.Ef.UserAgg;
using Shop.Infrastructure.Persistent.Ef.SiteEntities.Repositories;
using Shop.Infrastructure.Persistent.Dapper;

namespace Shop.Infrastructure;

public class InfrastructureBootstrapper
{
    public static void Init(IServiceCollection services,string connectionString)
    {
        services.AddTransient<ICategoryRepository, CategoryRepository>();
        services.AddTransient<IOrderRepository, OrderRepository>();
        services.AddTransient<IProductRepository, ProductRepository>();
        services.AddTransient<IRoleRepository, RoleRepository>();
        services.AddTransient<ISellerRepository, SellerRepository>();
        services.AddTransient<IBannerRepository, BannerRepository>();
        services.AddTransient<ISliderRepository, SliderRepository>();
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<ICommentRepository, CommentRepository>();
        services.AddTransient<IShippingMethodRepository, ShippingMethodRepository>();

        //services.AddSingleton<ICustomPublisher, CustomPublisher>();

        services.AddTransient(_ => new DapperContext(connectionString));
        services.AddDbContext<ShopContext>(option =>
        {
            option.UseSqlServer(connectionString);
        });
    }
}
