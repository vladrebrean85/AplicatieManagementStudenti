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

namespace AplicatieManagementStudenti.Pages.Inscrieri
{
    public class EditModel : PageModel
    {
        private readonly AplicatieManagementStudenti.Data.SchoolContext _context;

        public EditModel(AplicatieManagementStudenti.Data.SchoolContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Inscriere Inscriere { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Inscriere = await _context.Inscrieri
                .Include(i => i.Curs)
                .Include(i => i.Student).FirstOrDefaultAsync(m => m.InscriereID == id);

            if (Inscriere == null)
            {
                return NotFound();
            }
           ViewData["CursID"] = new SelectList(_context.Cursuri, "CursID", "CursID");
           ViewData["StudentID"] = new SelectList(_context.Studenti, "ID", "ID");
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

            _context.Attach(Inscriere).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InscriereExists(Inscriere.InscriereID))
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

        private bool InscriereExists(int id)
        {
            return _context.Inscrieri.Any(e => e.InscriereID == id);
        }
    }
}
