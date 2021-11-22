using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ToDoApplication.Data;
using ToDoApplication.Models;

namespace ToDoApplication.Areas.Admin.Pages.ToDosPage
{
    public class DeleteModel : PageModel
    {
        private readonly ToDoApplication.Data.ToDoApplicationContext _context;

        public DeleteModel(ToDoApplication.Data.ToDoApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ToDos ToDos { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ToDos = await _context.ToDo.FirstOrDefaultAsync(m => m.ToDosId == id);

            if (ToDos == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ToDos = await _context.ToDo.FindAsync(id);

            if (ToDos != null)
            {
                _context.ToDo.Remove(ToDos);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
