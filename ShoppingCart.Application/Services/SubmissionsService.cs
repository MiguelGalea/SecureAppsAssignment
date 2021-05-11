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
    public class SubmissionsService : ISubmissionsService
    {
        private ISubmissionsRepository _submissionsRepo;
        private IMapper _autoMapper;
        public SubmissionsService(ISubmissionsRepository submissionsRepo, IMapper autoMapper)
        {
            _submissionsRepo = submissionsRepo;
            _autoMapper = autoMapper;
        }

        public void AddSubmission(SubmissionViewModel model)
        {
            _submissionsRepo.AddSubmission(_autoMapper.Map<Submission>(model));
        }

        public SubmissionViewModel GetSubmission(Guid id)
        {
            var s = _submissionsRepo.GetSubmission(id);
            if (s == null) return null;
            else
            {
                var result = _autoMapper.Map<SubmissionViewModel>(s);
                return result;
            }
        }

        public IQueryable<SubmissionViewModel> GetSubmissions()
        {
            return _submissionsRepo.GetSubmissions().ProjectTo<SubmissionViewModel>(_autoMapper.ConfigurationProvider);
        }
    }
}
