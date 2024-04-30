using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Shop.Application._Utilities;
using Shop.Domain.SiteEntities;
using Shop.Domain.SiteEntities.IRepositories;

namespace Shop.Application.SiteEntities.Banners.Create
{
    public class CreateBannerCommandHandler : IBaseCommandHandler<CreateBannerCommand>
    {
        private readonly IFileService _fileService;
        private readonly IBannerRepository _repository;

        public CreateBannerCommandHandler(IFileService fileService, IBannerRepository repository)
        {
            _fileService = fileService;
            _repository = repository;
        }

        public async Task<OperationResult> Handle(CreateBannerCommand request, CancellationToken cancellationToken)
        {
            var imageName = await _fileService.SaveFileAndGenerateName(request.ImageFile, Directories.BannerImages);
            var banner = new Banner(request.Link, imageName, request.Position);


            _repository.Add(banner);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
