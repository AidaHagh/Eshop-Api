using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Shop.Application._Utilities;
using Shop.Domain.SiteEntities.IRepositories;

namespace Shop.Application.SiteEntities.Banners.Delete;

internal class DeleteBannerCommandHandler : IBaseCommandHandler<DeleteBannerCommand>
{
    private readonly IBannerRepository _repository;
    private readonly IFileService _fileService;

    public DeleteBannerCommandHandler(IBannerRepository repository, IFileService fileService)
    {
        _repository = repository;
        _fileService = fileService;
    }

    public async Task<OperationResult> Handle(DeleteBannerCommand request, CancellationToken cancellationToken)
    {
        var banner=await _repository.GetTracking(request.Id);
        if (banner == null)
            return OperationResult.NotFound();

        _repository.Delete(banner);
        await _repository.Save();
        _fileService.DeleteFile(Directories.BannerImages, banner.ImageName);

        return OperationResult.Success();
    }
}
