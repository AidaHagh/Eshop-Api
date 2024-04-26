using Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Comments.Edit
{
    public record EditCommentCommand(long commentId,string text,long userId) :IBaseCommand;
}
