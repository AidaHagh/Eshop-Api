using Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Comments.Create
{
    public record CreateCommentCommand(string text,long userId,long productId):IBaseCommand;
}
