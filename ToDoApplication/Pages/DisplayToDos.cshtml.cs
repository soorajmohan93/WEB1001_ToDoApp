using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ToDoApplication.Data;
using ToDoApplication.Models;

//This class OnGet method lets the view display all the records in the database

namespace ToDoApplication.Pages
{
    public class DisplayToDosModel : PageModel
    {
        public readonly ToDoApplicationContext db;

        public List<ToDos> toDo { get; set; }

        public DisplayToDosModel(ToDoApplicationContext dbContext)
        {
            db = dbContext;
        }

        public void OnGet()
        {
            toDo = db.ToDo.ToList();
        }
    }
}
