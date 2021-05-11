using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ShoppingCart.Domain.Models
{
    public class Submission
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string FileName { get; set; }

        public string Description { get; set; }

        public string Path { get; set; }

        public string Signature { get; set; }

        public string Owner { get; set; }

        public string Hash { get; set; }

        public DateTime TimeSubmitted { get; set; }

        [Required]
        public virtual Task Task { get; set; }

        [ForeignKey("Task")]
        public Guid TaskId { get; set; }

        public virtual IList<Comment> Comments { get; set; }

    }
}
