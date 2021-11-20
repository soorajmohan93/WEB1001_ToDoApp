using System;
using System.ComponentModel.DataAnnotations;

namespace ToDoApplication.Models
{
    public class ToDos
    {
        [StringLength(256, MinimumLength = 5)]
        public string Description { get; set; }

        public bool IsCompleted { get; set; }

        [Timestamp]
        public DateTime CompletedDate { get; set; }
    }
}
