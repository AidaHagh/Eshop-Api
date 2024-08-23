using Common.Application;
using Shop.Application.Products.AddImage;
using Shop.Application.Products.Create;
using Shop.Application.Products.Edit;
using Shop.Application.Products.RemoveImage;
using Shop.Domain.ProductAgg;
using Shop.Query.Products.DTOs;
using Shop.Query.Sellers.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Presentation.Facade.Products
{
    public interface IProductFacade
    {
        Task<OperationResult> AddProductImage(AddProductImageCommand command);
        Task<OperationResult> CreateProduct(CreateProductCommand command);
        Task<OperationResult> EditProduct(EditProductCommand command);
        Task<OperationResult> RemoveProductImage(RemoveProductImageCommand command);


        Task<ProductDto?> GetProductById(long id);    
        Task<ProductDto?> GetProductBySlug(string slug);
        Task<SingleProductDto?> GetProductBySlugForSinglePage(string slug);
        Task<ProductFilterResult> GetProductsByFilter(ProductFilterParams filterParams);
        Task<ProductShopResult> GetProductsForShop(ProductShopFilterParam filterParams);
    }

    public class SingleProductDto
    {
        public ProductDto ProductDto { get; set; }
        public List<InventoryDto> Inventories { get; set; }
    }
}
