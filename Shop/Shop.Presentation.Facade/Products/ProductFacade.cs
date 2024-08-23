using Common.Application;
using MediatR;
using Shop.Application.Products.AddImage;
using Shop.Application.Products.Create;
using Shop.Application.Products.Edit;
using Shop.Application.Products.RemoveImage;
using Shop.Query.Products.DTOs;
using Shop.Query.Products.GetByFilter;
using Shop.Query.Products.GetById;
using Shop.Query.Products.GetBySlug;

namespace Shop.Presentation.Facade.Products
{
    internal class ProductFacade : IProductFacade
    {
        private readonly IMediator _mediator;

        public ProductFacade(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<OperationResult> AddProductImage(AddProductImageCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> CreateProduct(CreateProductCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> EditProduct(EditProductCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<ProductDto?> GetProductById(long id)
        {
            return await _mediator.Send(new GetProductByIdQuery(id));
        }

        public async Task<ProductDto?> GetProductBySlug(string slug)
        {
            return await _mediator.Send(new GetProductBySlugQuery(slug));
        }

        public Task<SingleProductDto?> GetProductBySlugForSinglePage(string slug)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductFilterResult> GetProductsByFilter(ProductFilterParams filterParams)
        {
            return await _mediator.Send(new GetProductsByFilterQuery(filterParams));
        }

        public Task<ProductShopResult> GetProductsForShop(ProductShopFilterParam filterParams)
        {
            throw new NotImplementedException();
        }

        public async Task<OperationResult> RemoveProductImage(RemoveProductImageCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
