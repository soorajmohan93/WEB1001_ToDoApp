using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ToDoApplication.Models;
using ToDoApplication.Data;

//This is the IndexModel class, which controls the Homepage

namespace ToDoApplication.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public readonly ToDoApplicationContext db;

        public List<ToDos> toDo { get; set; }

        [FromForm]
        public ToDos toDoEntry { get; set; }

        public IndexModel(ILogger<IndexModel> logger, ToDoApplicationContext dbContext)
        {
            _logger = logger;
            db = dbContext;   

        }

        public void OnGet()
        {
            //The below code displays only the incomplete entries
            toDo = db.ToDo.Where(b => b.IsCompleted == false).ToList();
        }

        public void OnPost()
        {
            // If valid entry is entered then proceed
            if (ModelState.IsValid)
            {
                // If IsCompleted is true then give current date/time to CompletedDate or else give null
                if (toDoEntry.IsCompleted)
                {
                    toDoEntry.CompletedDate = DateTime.Now;
                }
                else
                {
                    toDoEntry.CompletedDate = null;
                }
                //Add the entry to the db and save changes
                db.ToDo.Add(toDoEntry);
                db.SaveChanges();
            }
            //The below code displays only the incomplete entries
            toDo = db.ToDo.Where(b => b.IsCompleted == false).ToList();
        }
    }
}
