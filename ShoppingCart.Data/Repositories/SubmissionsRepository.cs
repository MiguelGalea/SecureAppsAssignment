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
    public class SubmissionsRepository : ISubmissionsRepository
    {
        ShoppingCartDbContext _context;

        public SubmissionsRepository(ShoppingCartDbContext context)
        {
            _context = context;
        }

        public Guid AddSubmission(Submission s)
        {
            s.Id = Guid.NewGuid();
            _context.Submissions.Add(s);
            _context.SaveChanges();

            return s.Id;
        }

        public Submission GetSubmission(Guid id)
        {
            return _context.Submissions.Include(x => x.Task).SingleOrDefault(x => x.Id == id);
        }

        public IQueryable<Submission> GetSubmissions()
        {
            return _context.Submissions.Include(x => x.Task);
        }
    }
}
