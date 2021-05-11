using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Application.ViewModels
{
    public class SubmissionViewModel
    {
        public Guid Id { get; set; }

        public string FileName { get; set; }

        public string Description { get; set; }

        public string Path { get; set; }

        public string Signature { get; set; }

        public string Owner { get; set; }

        public string Hash { get; set; }

        public DateTime TimeSubmitted { get; set; }

        public TaskViewModel Task { get; set; }

        public Guid TaskId { get; set; }

        public virtual IList<Comment> Comments { get; set; }

    }
}
