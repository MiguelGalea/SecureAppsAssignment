using ShoppingCart.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Application.Interfaces
{
    public interface ICommentsService
    {
        IQueryable<CommentViewModel> GetComments();

        CommentViewModel GetComment(Guid id);

        void AddComment(CommentViewModel model);
    }
}
