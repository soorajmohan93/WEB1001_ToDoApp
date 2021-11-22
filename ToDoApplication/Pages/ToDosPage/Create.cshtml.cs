using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ToDoApplication.Data;
using ToDoApplication.Models;

namespace ToDoApplication.Areas.Admin.Pages.ToDosPage
{
    public class CreateModel : PageModel
    {
        private readonly ToDoApplication.Data.ToDoApplicationContext _context;

        public CreateModel(ToDoApplication.Data.ToDoApplicationContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ToDos ToDos { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ToDo.Add(ToDos);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
