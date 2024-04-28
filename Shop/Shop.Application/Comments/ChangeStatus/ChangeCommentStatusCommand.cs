using Common.Application;
using FluentValidation;
using Shop.Application.Comments.ChangeStatus;
using Shop.Domain.CommentAgg.Enum;
using Shop.Domain.CommentAgg.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Comments.ChangeStatus;

public record ChangeCommentStatusCommand(long commentId, CommentStatus status) : IBaseCommand;




public class ChangeCommentStatusCommandHandler : IBaseCommandHandler<ChangeCommentStatusCommand>
{
    private readonly ICommentRepository _repository;

    public ChangeCommentStatusCommandHandler(ICommentRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> Handle(ChangeCommentStatusCommand request, CancellationToken cancellationToken)
    {
        var comment = await _repository.GetTracking(request.commentId);
        if (comment == null)
            return OperationResult.NotFound();
        comment.ChangeStatus(request.status);
        await _repository.Save();
        return OperationResult.Success();
    }
}



