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
        public string Description { get; set; }

        public bool IsCompleted { get; set; }

        public DateTime? CompletedDate { get; set; }
    }
}
