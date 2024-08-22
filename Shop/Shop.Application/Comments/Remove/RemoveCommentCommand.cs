using Common.Application;
using Shop.Domain.CommentAgg.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Comments.Remove;

public record RemoveCommentCommand(long CommentId, long UserId) : IBaseCommand;


public class RemoveCommentCommandHandler : IBaseCommandHandler<RemoveCommentCommand>
{
    private readonly ICommentRepository _repository;

    public RemoveCommentCommandHandler(ICommentRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> Handle(RemoveCommentCommand request, CancellationToken cancellationToken)
    {
        var comment = await _repository.GetTracking(request.CommentId,cancellationToken);
        if (comment == null || comment.UserId != request.UserId)
            return OperationResult.NotFound();

        await _repository.RemoveAndSave(comment);
        return OperationResult.Success();
    }
}