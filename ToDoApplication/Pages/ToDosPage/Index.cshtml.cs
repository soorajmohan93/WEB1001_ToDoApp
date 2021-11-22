using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ToDoApplication.Data;
using ToDoApplication.Models;
using ToDoApplication.Pages;

namespace ToDoApplication.Areas.Admin.Pages.ToDosPage
{
    public class IndexModel : PageModel
    {
        private readonly ToDoApplication.Data.ToDoApplicationContext _context;

        public IndexModel(ToDoApplication.Data.ToDoApplicationContext context)
        {
            _context = context;
        }

        public IList<ToDos> ToDos { get;set; }

        public async Task OnGetAsync()
        {
            ToDos = await _context.ToDo.ToListAsync();
        }
    }
}
