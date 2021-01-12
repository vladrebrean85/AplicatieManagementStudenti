using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AplicatieManagementStudenti.Data;
using AplicatieManagementStudenti.Models;

namespace AplicatieManagementStudenti.Pages.Inscrieri
{
    public class DetailsModel : PageModel
    {
        private readonly AplicatieManagementStudenti.Data.SchoolContext _context;

        public DetailsModel(AplicatieManagementStudenti.Data.SchoolContext context)
        {
            _context = context;
        }

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
            return Page();
        }
    }
}
