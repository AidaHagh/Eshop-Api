using Common.Application;
using Shop.Application.SiteEntities.Sliders.Create;
using Shop.Application.SiteEntities.Sliders.Edit;
using Shop.Domain.SiteEntities;
using Shop.Query.SiteEntities.DTOs;


namespace Shop.Presentation.Facade.SiteEntities.Sliders
{
    public interface ISliderFacade
    {
        Task<OperationResult> CreateSlider(CreateSliderCommand command);
        Task<OperationResult> EditSlider(EditSliderCommand command);
        Task<OperationResult> DeleteSlider(long sliderId);


        Task<SliderDto?> GetSliderById(long sliderId); 
        Task<List<SliderDto>> GetSlidersList(); 
    }
}
