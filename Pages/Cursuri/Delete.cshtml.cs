using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AplicatieManagementStudenti.Data;
using AplicatieManagementStudenti.Models;

namespace AplicatieManagementStudenti.Pages.Cursuri
{
    public class DeleteModel : PageModel
    {
        private readonly AplicatieManagementStudenti.Data.SchoolContext _context;

        public DeleteModel(AplicatieManagementStudenti.Data.SchoolContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Curs Curs { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Curs = await _context.Cursuri.FirstOrDefaultAsync(m => m.CursID == id);

            if (Curs == null)
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

            Curs = await _context.Cursuri.FindAsync(id);

            if (Curs != null)
            {
                _context.Cursuri.Remove(Curs);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
