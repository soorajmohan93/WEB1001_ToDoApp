using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

//This is the model used by the Todo application.
//ToDosId is the primary key to identify each todo entry
//Description is the To-Do text
//IsCompleted is boolean which marks the to-do is completed or not
//CompletedDate is given the date and time when the IsCompleted is checked yes

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
