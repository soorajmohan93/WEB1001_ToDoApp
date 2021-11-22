using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ToDoApplication.Models;
using ToDoApplication.Data;

namespace ToDoApplication.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        //public ToDoApplicationContext db = new ToDoApplicationContext();
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
            toDo = db.ToDo.Where(b => b.IsCompleted == false).ToList();
        }

        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                if (toDoEntry.IsCompleted)
                {
                    toDoEntry.CompletedDate = DateTime.Now;
                }
                db.ToDo.Add(toDoEntry);
                db.SaveChanges();
            }
            toDo = db.ToDo.ToList();
        }
    }
}
