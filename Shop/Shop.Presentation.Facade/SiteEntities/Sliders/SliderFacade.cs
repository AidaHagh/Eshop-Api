using Common.Application;
using MediatR;
using Shop.Application.SiteEntities.Sliders.Create;
using Shop.Application.SiteEntities.Sliders.Delete;
using Shop.Application.SiteEntities.Sliders.Edit;
using Shop.Query.SiteEntities.DTOs;
using Shop.Query.SiteEntities.Sliders.GetById;
using Shop.Query.SiteEntities.Sliders.GetList;


namespace Shop.Presentation.Facade.SiteEntities.Sliders
{
    internal class SliderFacade : ISliderFacade
    {
        private readonly IMediator _mediator;
        public SliderFacade(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<OperationResult> CreateSlider(CreateSliderCommand command)
        {
           return await _mediator.Send(command);    
        }

        public async Task<OperationResult> DeleteSlider(long sliderId)
        {
            return await _mediator.Send(new DeleteSliderCommand(sliderId));
        }

        public async Task<OperationResult> EditSlider(EditSliderCommand command)
        {
            return await _mediator.Send(command);

        }

        public async Task<SliderDto?> GetSliderById(long sliderId)
        {
            return await _mediator.Send(new GetSliderByIdQuery(sliderId));
        }

        public async Task<List<SliderDto>> GetSlidersList()
        {
            return await _mediator.Send(new GetSliderListQuery());
        }
    }
}
