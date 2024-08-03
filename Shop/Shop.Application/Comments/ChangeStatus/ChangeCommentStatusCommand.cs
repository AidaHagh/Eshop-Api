using Common.Application;
using FluentValidation;
using Shop.Application.Comments.ChangeStatus;
using Shop.Domain.CommentAgg.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Comments.ChangeStatus;

public record ChangeCommentStatusCommand(long commentId, CommentStatus status) : IBaseCommand;



