using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AplicatieManagementStudenti.Data;
using AplicatieManagementStudenti.Models;

namespace AplicatieManagementStudenti.Pages.Cursuri
{
    public class EditModel : PageModel
    {
        private readonly AplicatieManagementStudenti.Data.SchoolContext _context;

        public EditModel(AplicatieManagementStudenti.Data.SchoolContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Curs).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CursExists(Curs.CursID))
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

        private bool CursExists(int id)
        {
            return _context.Cursuri.Any(e => e.CursID == id);
        }
    }
}
