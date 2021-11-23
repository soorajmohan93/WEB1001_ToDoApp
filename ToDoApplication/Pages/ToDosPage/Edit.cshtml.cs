using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ToDoApplication.Data;
using ToDoApplication.Models;

namespace ToDoApplication.Areas.Admin.Pages.ToDosPage
{
    public class EditModel : PageModel
    {
        private readonly ToDoApplication.Data.ToDoApplicationContext _context;

        public EditModel(ToDoApplication.Data.ToDoApplicationContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ToDos).State = EntityState.Modified;

            //The below code gives the CompletedDate the current date and time if IsCompleted is marked true
            if (ToDos.IsCompleted)
            {
                ToDos.CompletedDate = DateTime.Now;
            }
            else
            {
                ToDos.CompletedDate = null;
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ToDosExists(ToDos.ToDosId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ToDosExists(int id)
        {
            return _context.ToDo.Any(e => e.ToDosId == id);
        }
    }
}
