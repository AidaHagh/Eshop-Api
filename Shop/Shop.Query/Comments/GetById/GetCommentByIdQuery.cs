using Common.Query;
using Shop.Query.Comments.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.Comments.GetById;

public record GetCommentByIdQuery(long CommentId):IQuery<CommentDto?>;
