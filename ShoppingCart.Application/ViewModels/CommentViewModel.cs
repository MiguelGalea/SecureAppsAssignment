using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ShoppingCart.Application.ViewModels
{
    public class CommentViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Content cannot be empty")]
        public string Content { get; set; }

        public string Author { get; set; }

        public DateTime Posted { get; set; }

        public virtual Submission Submission { get; set; }

        [ForeignKey("Submission")]
        public Guid SubmissionId { get; set; }
    }
}
