using Common.Query;
using Shop.Query.Comments.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.Comments.GetByFilter
{
    public class GetCommentByFilterQuery : QueryFilter<CommentFilterResult, CommentFilterParams>
    {
        public GetCommentByFilterQuery(CommentFilterParams filterParams) : base(filterParams)
        {
        }
    }
}
