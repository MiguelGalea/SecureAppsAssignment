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
    public class TasksService : ITasksService
    {
        private ITasksRepository _tasksRepo;
        private IMapper _autoMapper;
        public TasksService(ITasksRepository tasksRepo, IMapper autoMapper)
        {
            _tasksRepo = tasksRepo;
            _autoMapper = autoMapper;
        }

        public void AddTask(TaskViewModel model)
        {
            _tasksRepo.AddTask(_autoMapper.Map<Task>(model));
        }

        public IQueryable<TaskViewModel> GetTasks()
        {
            return _tasksRepo.GetTasks().ProjectTo<TaskViewModel>(_autoMapper.ConfigurationProvider);
        }
    }
}
