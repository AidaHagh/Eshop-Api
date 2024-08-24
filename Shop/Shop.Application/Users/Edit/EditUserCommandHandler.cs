using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Microsoft.AspNetCore.Http;
using Shop.Application._Utilities;
using Shop.Domain.UserAgg.IRepository;
using Shop.Domain.UserAgg.Services;

namespace Shop.Application.Users.Edit
{
    internal class EditUserCommandHandler : IBaseCommandHandler<EditUserCommand>
    {
        private readonly IUserDomainService _domainService;
        private readonly IUserRepository _Repository;
        private readonly IFileService _fileService;

        public EditUserCommandHandler(IUserDomainService domainService, IUserRepository userRepository, IFileService fileService)
        {
            _domainService = domainService;
            _Repository = userRepository;
            _fileService = fileService;
        }

        public async Task<OperationResult> Handle(EditUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _Repository.GetTracking(request.UserId, cancellationToken);
            if (user == null)
                return OperationResult.NotFound();
            var oldAvatar = user.AvatarName;
            user.Edit(request.Name, request.Family, request.PhoneNumber, request.Email, request.Gender, _domainService);

            if (request.AvatarName != null)
            {
                var imgName = await _fileService.SaveFileAndGenerateName(request.AvatarName, Directories.UserAvatars);
                user.SetAvatar(imgName);
            }
            DeleteOldAvatar(request.AvatarName, oldAvatar);
            await _Repository.Save();
            return OperationResult.Success();

        }

        private void DeleteOldAvatar(IFormFile? avatarFile, string oldImage)
        {
            if (avatarFile == null || oldImage == "avatar.png")
                return;
            _fileService.DeleteFile(Directories.UserAvatars,oldImage);

        }

    }
}
