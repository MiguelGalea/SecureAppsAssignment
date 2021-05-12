using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShoppingCart.Application.Interfaces;
using ShoppingCart.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITasksService _tasksService;
        private readonly ISubmissionsService _submissionService;
        private readonly IWebHostEnvironment _host;
        private readonly ILogger<ProductsController> _logger;
        public TaskController(ITasksService tasksService, IWebHostEnvironment host, ILogger<ProductsController> logger, ISubmissionsService submissionService)
        {
            _logger = logger;
            _host = host;
            _tasksService = tasksService;
            _submissionService = submissionService;
        }
        public IActionResult Index()
        {
            var list = _tasksService.GetTasks();
            return View(list);
        }

        [HttpGet]
        [Authorize(Roles = "TEACHER")]
        public IActionResult Create()
        { return View(); }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "TEACHER")]
        public IActionResult Create(TaskViewModel newTask)
        {
            newTask.Id = new Guid();
            newTask.Teacher = HttpContext.User.Identity.Name;

            if(newTask.Deadline < DateTime.Now)
            {
                _logger.LogError("Deadline is inavlid");
                return View("Error", new ErrorViewModel() { Message = "Deadline Date cannot be in the past" });
            }
            else if (string.IsNullOrEmpty(newTask.Title))
            {
                _logger.LogError("Title is empty or NULL");
                return View("Error", new ErrorViewModel() { Message = "Title cannot be empty" });
            }
            else if (string.IsNullOrEmpty(newTask.Description))
            {
                _logger.LogError("Description is empty or NULL");
                return View("Error", new ErrorViewModel() { Message = "Description cannot be empty" });
            }
            else
            {
                TempData["message"] = "Task created successfully";
                _tasksService.AddTask(newTask);
                return View();
            }
        }

        public IActionResult Submission(SubmissionViewModel newSub)
        {
            newSub.Id = new Guid();
            newSub.Owner = HttpContext.User.Identity.Name;
            newSub.TimeSubmitted = DateTime.Now;

            if (string.IsNullOrEmpty(newSub.FileName))
            {
                _logger.LogError("Title is empty or NULL");
                return View("Error", new ErrorViewModel() { Message = "Title cannot be empty" });
            }
            else
            {
                TempData["message"] = "Task created successfully";
                _submissionService.AddSubmission(newSub);
                return View();
            }
        }
    }
}
