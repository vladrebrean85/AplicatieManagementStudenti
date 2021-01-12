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
    public class DetailsModel : PageModel
    {
        private readonly AplicatieManagementStudenti.Data.SchoolContext _context;

        public DetailsModel(AplicatieManagementStudenti.Data.SchoolContext context)
        {
            _context = context;
        }

        public Curs Curs { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Curs = await _context.Cursuri
                .Include(s => s.Inscrieri)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.CursID == id);

            if (Curs == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
