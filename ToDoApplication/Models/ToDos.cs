using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ToDoApplication.Models
{
    
    public class ToDos
    {
        [Required]
        public int ToDosId { get; set; }

        [Required]
        [StringLength(256, MinimumLength = 5)]
        [Display(Name = "To-do", Description = "Enter a To-do")]
        public string Description { get; set; }

        [Display(Name = "Is this Completed?", Description = "Is this Completed?")]
        public bool IsCompleted { get; set; }

        [Display(Name = "Completed Date", Description = "Completed Date")]
        public DateTime? CompletedDate { get; set; }
    }
}
