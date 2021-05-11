using AutoMapper;
using AutoMapper.QueryableExtensions;
using ShoppingCart.Application.Interfaces;
using ShoppingCart.Application.ViewModels;
using ShoppingCart.Domain.Interfaces;
using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Application.Services
{
    public class CommentsService : ICommentsService
    {
        private ICommentsRepository _commentsRepo;
        private IMapper _autoMapper;
        public CommentsService(ICommentsRepository commentsRepo, IMapper autoMapper)
        {
            _commentsRepo = commentsRepo;
            _autoMapper = autoMapper;
        }

        public void AddComment(CommentViewModel model)
        {
            _commentsRepo.AddComment(_autoMapper.Map<Comment>(model));
        }

        public CommentViewModel GetComment(Guid id)
        {
            var c = _commentsRepo.GetComment(id);
            if (c == null) return null;
            else
            {
                var result = _autoMapper.Map<CommentViewModel>(c);
                return result;
            }
        }

        public IQueryable<CommentViewModel> GetComments()
        {
            return _commentsRepo.GetComments().ProjectTo<CommentViewModel>(_autoMapper.ConfigurationProvider);
        }
    }
}
