using Microsoft.EntityFrameworkCore;
using ShoppingCart.Data.Context;
using ShoppingCart.Domain.Interfaces;
using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Data.Repositories
{
    public class CommentsRepository : ICommentsRepository
    {
        ShoppingCartDbContext _context;

        public CommentsRepository(ShoppingCartDbContext context)
        {
            _context = context;
        }

        public Guid AddComment(Comment c)
        {
            c.Id = Guid.NewGuid();
            _context.Comments.Add(c);
            _context.SaveChanges();

            return c.Id;
        }

        public Comment GetComment(Guid id)
        {
            return _context.Comments.Include(x => x.Submission).SingleOrDefault(x => x.Id == id);
        }

        public IQueryable<Comment> GetComments()
        {
            return _context.Comments.Include(x => x.Submission);
        }
    }
}
