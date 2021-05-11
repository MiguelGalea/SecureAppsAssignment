using ShoppingCart.Data.Context;
using ShoppingCart.Domain.Interfaces;
using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Data.Repositories
{
    public class TasksRepository : ITasksRepository
    {
        ShoppingCartDbContext _context;

        public TasksRepository(ShoppingCartDbContext context)
        {
            _context = context;
        }

        public Guid AddTask(Task t)
        {
            t.Id = Guid.NewGuid();
            _context.Tasks.Add(t);
            _context.SaveChanges();

            return t.Id;
        }

        public IQueryable<Task> GetTasks(string teacherEmail)
        {
            return _context.Tasks.Where(x => x.Teacher == teacherEmail);
        }
    }
}
