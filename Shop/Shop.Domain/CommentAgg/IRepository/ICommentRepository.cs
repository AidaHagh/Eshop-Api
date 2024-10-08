﻿using Common.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.CommentAgg.IRepository
{
    public interface ICommentRepository : IBaseRepository<Comment>
    {
        Task RemoveAndSave(Comment comment);
    }
}
