using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Microsoft.AspNetCore.Http;
using Shop.Application._Utilities;
using Shop.Domain.SiteEntities.IRepositories;

namespace Shop.Application.SiteEntities.Banners.Edit
{
    internal class EditBannerCommandHandler : IBaseCommandHandler<EditBannerCommand>
    {
        private readonly IFileService _fileService;
        private readonly IBannerRepository _repository;

        public EditBannerCommandHandler(IFileService fileService, IBannerRepository repository)
        {
            _fileService = fileService;
            _repository = repository;
        }

        public async Task<OperationResult> Handle(EditBannerCommand request, CancellationToken cancellationToken)
        {
            var banner = await _repository.GetTracking(request.Id);
            if (banner == null)
                return OperationResult.NotFound();

            var imageName=banner.ImageName;
            var oldImage=banner.ImageName;
            if (request.ImageFile != null)
                imageName =await _fileService.SaveFileAndGenerateName(request.ImageFile, Directories.BannerImages);

            banner.Edit(request.Link, imageName, request.Position);

            DeleteOldImage(request.ImageFile,oldImage);
            await _repository.Save();
            return OperationResult.Success();
        }

        public void DeleteOldImage(IFormFile? imageFile, string oldImage)
        {
            if (imageFile != null)
                _fileService.DeleteFile(Directories.SliderImages, oldImage);
        }
    }
}
